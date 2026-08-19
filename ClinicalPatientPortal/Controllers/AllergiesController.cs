using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/allergies")]
    public class AllergiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AllergiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllergies(int patientId)
        {
            if (!_context.Patients.Any(p => p.PatientId == patientId))
                return NotFound($"Patient {patientId} not found.");

            var allergies = _context.Allergies
                .Where(a => a.PatientId == patientId)
                .Select(a => new AllergyDto
                {
                    AllergyId = a.AllergyId,
                    AllergyName = a.AllergyName,
                    Severity = a.Severity,
                    Status = a.Status,
                    RecordedDate = a.RecordedDate
                })
                .ToList();

            return Ok(allergies);
        }
    }
}
