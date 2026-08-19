using ClinicalPatientPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IPatientDataService _patientDataService;
        private readonly string _documentsRootPath;

        public DocumentsController(IPatientDataService patientDataService, IWebHostEnvironment env)
        {
            _patientDataService = patientDataService;
            _documentsRootPath = Path.Combine(env.ContentRootPath, "PatientDocuments");
        }


        [HttpGet]
        public async Task<IActionResult> GetDocumentsAsync(int patientId)
        {
            if (!await _patientDataService.PatientExistsAsync(patientId))
                return NotFound($"Patient {patientId} not found.");

            return Ok(await _patientDataService.GetDocumentsAsync(patientId));
        }

        [HttpGet("{documentId}/download")]
        public async Task<IActionResult> DownloadDocumentAsync(int patientId, int documentId)
        {
            var doc = await _patientDataService.GetDocumentEntityAsync(patientId, documentId);
            if (doc == null) return NotFound();

            var relativePath = doc.FilePath.TrimStart('/', '\\');
            var fullPath = Path.Combine(_documentsRootPath, relativePath);
            if (!System.IO.File.Exists(fullPath)) return NotFound();

            var contentType = GetContentType(doc.DocumentType);
            var bytes = System.IO.File.ReadAllBytes(fullPath);
            return File(bytes, contentType, doc.DocumentName);
        }

        private static string GetContentType(string documentType) => documentType?.ToLower() switch
        {
            "pdf" => "application/pdf",
            "image" or "jpg" or "jpeg" or "png" => "image/jpeg",
            "word" or "docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            _ => "application/octet-stream"
        };
    }
}
