using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string _documentsRootPath;

        public DocumentsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _documentsRootPath = Path.Combine(env.ContentRootPath, "PatientDocuments");
        }


        [HttpGet]
        public IActionResult GetDocuments(int patientId)
        {
            if (!_context.Patients.Any(p => p.PatientId == patientId))
                return NotFound($"Patient {patientId} not found.");

            var documents = _context.Documents
                .Where(d => d.PatientId == patientId)
                .Select(d => new DocumentDto
                {
                    DocumentId = d.DocumentId,
                    DocumentName = d.DocumentName,
                    DocumentType = d.DocumentType,
                    DocumentDate = d.DocumentDate,
                    UploadedDate = d.UploadedDate
                })
                .ToList();

            return Ok(documents);
        }

        [HttpGet("{documentId}/download")]
        public IActionResult DownloadDocument(int patientId, int documentId)
        {
            var doc = _context.Documents.FirstOrDefault(d => d.DocumentId == documentId && d.PatientId == patientId);
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
