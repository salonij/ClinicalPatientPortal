using ClinicalPatientPortal.Models;
using ClinicalPatientPortal.Models.Dtos;

namespace ClinicalPatientPortal.Services
{
    public interface IPatientDataService
    {
        Task<bool> PatientExistsAsync(int patientId);
        Task<PatientDetailDto?> GetPatientDetailAsync(int patientId);
        Task<List<AllergyDto>> GetAllergiesAsync(int patientId);
        Task<List<AlertDto>> GetAlertsAsync(int patientId);
        Task<List<MedicationDto>> GetMedicationsAsync(int patientId);
        Task<List<DocumentDto>> GetDocumentsAsync(int patientId);
        Task<Document?> GetDocumentEntityAsync(int patientId, int documentId);
    }
}
