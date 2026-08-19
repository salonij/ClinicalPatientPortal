namespace ClinicalPatientPortal.Models.Dtos
{
    public class AlertDto
    {
        public int AlertId { get; set; }
        public string AlertType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Severity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
