using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicalPatientPortal.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? mrn,
            [FromQuery] string? dob,
            [FromQuery] string? firstName,
            [FromQuery] string? lastName,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            if (page < 1) page = 1;
            if (pageSize < 1 || pageSize > 100) pageSize = 5;

            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(mrn))
                query = query.Where(p => p.MRN.Contains(mrn));

            if (!string.IsNullOrWhiteSpace(dob) && DateTime.TryParse(dob, out var parsedDob))
                query = query.Where(p => p.DOB.Date == parsedDob.Date);

            if (!string.IsNullOrWhiteSpace(firstName))
                query = query.Where(p => p.FirstName.Contains(firstName));

            if (!string.IsNullOrWhiteSpace(lastName))
                query = query.Where(p => p.LastName.Contains(lastName));

            query = query.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PatientSearchResultDto
                {
                    PatientId = p.PatientId,
                    MRN = p.MRN,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DOB = p.DOB,
                    Gender = p.Gender
                })
                .ToListAsync();

            return Ok(new PagedResult<PatientSearchResultDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetDemographics(int id)
        {
            if (!_context.Patients.Any(p => p.PatientId == id))
                return NotFound($"Patient {id} not found.");

            var patient = _context.Patients
                .Where(p => p.PatientId == id)
                .Select(p => new PatientDetailDto
                {
                    PatientId = p.PatientId,
                    MRN = p.MRN,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DOB = p.DOB,
                    Gender = p.Gender,
                    PhoneNumber = p.PhoneNumber,
                    AddressLine1 = p.AddressLine1,
                    City = p.City,
                    State = p.State,
                    ZipCode = p.ZipCode
                })
                .FirstOrDefault();

            return Ok(patient);
        }
    }
}
