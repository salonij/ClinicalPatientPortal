using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalPatientPortal.Models
{
    public class Medication
    {
        public int MedicationId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        [Required, MaxLength(100)]
        public string MedicationName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Strength { get; set; }

        [MaxLength(200)]
        public string? DosageInstructions { get; set; }

        [MaxLength(50)]
        public string? Frequency { get; set; }

        [MaxLength(50)]
        public string? Route { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [MaxLength(100)]
        public string? PrescribingProvider { get; set; }

        [MaxLength(20)]
        public string? Status { get; set; }
    }
}
