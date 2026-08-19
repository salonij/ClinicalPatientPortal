using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/medications")]
    public class MedicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMedications(int patientId)
        {
            if (!_context.Patients.Any(p => p.PatientId == patientId))
                return NotFound($"Patient {patientId} not found.");

            var medications = _context.Medications
                .Where(m => m.PatientId == patientId)
                .Select(m => new MedicationDto
                {
                    MedicationId = m.MedicationId,
                    MedicationName = m.MedicationName,
                    Strength = m.Strength,
                    DosageInstructions = m.DosageInstructions,
                    Frequency = m.Frequency,
                    Route = m.Route,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    PrescribingProvider = m.PrescribingProvider,
                    Status = m.Status
                })
                .ToList();

            return Ok(medications);
        }
    }
}
