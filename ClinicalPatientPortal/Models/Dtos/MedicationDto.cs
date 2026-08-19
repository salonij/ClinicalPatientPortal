namespace ClinicalPatientPortal.Models.Dtos
{
    public class MedicationDto
    {
        public int MedicationId { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string? Strength { get; set; }
        public string? DosageInstructions { get; set; }
        public string? Frequency { get; set; }
        public string? Route { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PrescribingProvider { get; set; }
        public string? Status { get; set; }
    }
}
