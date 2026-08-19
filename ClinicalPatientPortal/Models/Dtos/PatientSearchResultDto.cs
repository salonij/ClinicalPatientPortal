namespace ClinicalPatientPortal.Models.Dtos
{
    public class PatientSearchResultDto
    {
        public int PatientId { get; set; }
        public string MRN { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
    }
}
