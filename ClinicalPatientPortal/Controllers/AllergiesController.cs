using ClinicalPatientPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/allergies")]
    public class AllergiesController : ControllerBase
    {
        private readonly IPatientDataService _patientDataService;

        public AllergiesController(IPatientDataService patientDataService)
        {
            _patientDataService = patientDataService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllergies(int patientId)
        {
            if (!await _patientDataService.PatientExistsAsync(patientId))
                return NotFound($"Patient {patientId} not found.");

            return Ok(await _patientDataService.GetAllergiesAsync(patientId));
        }
    }
}
