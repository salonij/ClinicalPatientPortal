using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ClinicalPatientPortal.Services
{
    public class PatientDataService : IPatientDataService
    {
        private readonly ApplicationDbContext _context;

        public PatientDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        //check whether patient exists
        public Task<bool> PatientExistsAsync(int patientId) =>
            _context.Patients.AnyAsync(p => p.PatientId == patientId);

        //fetch patient's details
        public Task<PatientDetailDto?> GetPatientDetailAsync(int patientId) =>
            _context.Patients
                .Where(p => p.PatientId == patientId)
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
                .FirstOrDefaultAsync();

        //fetch allergies of patient
        public Task<List<AllergyDto>> GetAllergiesAsync(int patientId) =>
            _context.Allergies
                .Where(a => a.PatientId == patientId)
                .Select(a => new AllergyDto
                {
                    AllergyId = a.AllergyId,
                    AllergyName = a.AllergyName,
                    Severity = a.Severity,
                    Status = a.Status,
                    RecordedDate = a.RecordedDate
                })
                .ToListAsync();

        //fetch alerts related to patient
        public Task<List<AlertDto>> GetAlertsAsync(int patientId) =>
            _context.Alerts
                .Where(a => a.PatientId == patientId)
                .Select(a => new AlertDto
                {
                    AlertId = a.AlertId,
                    AlertType = a.AlertType,
                    Description = a.Description,
                    Severity = a.Severity,
                    CreatedDate = a.CreatedDate
                })
                .ToListAsync();

        //fetch medications related to patient
        public Task<List<MedicationDto>> GetMedicationsAsync(int patientId) =>
            _context.Medications
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
                .ToListAsync();

        //fetch documents related to patient
        public Task<List<DocumentDto>> GetDocumentsAsync(int patientId) =>
            _context.Documents
                .Where(d => d.PatientId == patientId)
                .Select(d => new DocumentDto
                {
                    DocumentId = d.DocumentId,
                    DocumentName = d.DocumentName,
                    DocumentType = d.DocumentType,
                    DocumentDate = d.DocumentDate,
                    UploadedDate = d.UploadedDate
                })
                .ToListAsync();

        //fetch a document based on document id and patient id
        public Task<Document?> GetDocumentEntityAsync(int patientId, int documentId) =>
            _context.Documents.FirstOrDefaultAsync(d => d.DocumentId == documentId && d.PatientId == patientId);
    }
}
