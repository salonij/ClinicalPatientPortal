using ClinicalPatientPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/medications")]
    public class MedicationsController : ControllerBase
    {
        private readonly IPatientDataService _patientDataService;

        public MedicationsController(IPatientDataService patientDataService)
        {
            _patientDataService = patientDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicationsAsync(int patientId)
        {
            if (!await _patientDataService.PatientExistsAsync(patientId))
                return NotFound($"Patient {patientId} not found.");

            return Ok(await _patientDataService.GetMedicationsAsync(patientId));
        }
    }
}
