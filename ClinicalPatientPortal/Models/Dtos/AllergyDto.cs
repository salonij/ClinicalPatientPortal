namespace ClinicalPatientPortal.Models.Dtos
{
    public class AllergyDto
    {
        public int AllergyId { get; set; }
        public string AllergyName { get; set; } = string.Empty;
        public string? Severity { get; set; }
        public string? Status { get; set; }
        public DateTime RecordedDate { get; set; }
    }
}
