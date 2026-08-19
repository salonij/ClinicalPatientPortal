using ClinicalPatientPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/alerts")]
    public class AlertsController : ControllerBase
    {
        private readonly IPatientDataService _patientDataService;

        public AlertsController(IPatientDataService patientDataService)
        {
            _patientDataService = patientDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlertsAsync(int patientId)
        {
            if (!await _patientDataService.PatientExistsAsync(patientId))
                return NotFound($"Patient {patientId} not found.");

            return Ok(await _patientDataService.GetAlertsAsync(patientId));
        }
    }
}
