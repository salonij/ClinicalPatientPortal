using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/alerts")]
    public class AlertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAlerts(int patientId)
        {
            if (!_context.Patients.Any(p => p.PatientId == patientId))
                return NotFound($"Patient {patientId} not found.");

            var alerts = _context.Alerts
                .Where(a => a.PatientId == patientId)
                .Select(a => new AlertDto
                {
                    AlertId = a.AlertId,
                    AlertType = a.AlertType,
                    Description = a.Description,
                    Severity = a.Severity,
                    CreatedDate = a.CreatedDate
                })
                .ToList();

            return Ok(alerts);
        }
    }
}
