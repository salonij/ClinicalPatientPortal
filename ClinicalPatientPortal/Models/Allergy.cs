using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalPatientPortal.Models
{
    public class Allergy
    {
        public int AllergyId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        [Required, MaxLength(100)]
        public string AllergyName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Severity { get; set; }

        [MaxLength(20)]
        public string? Status { get; set; }

        public DateTime RecordedDate { get; set; }
    }
}
