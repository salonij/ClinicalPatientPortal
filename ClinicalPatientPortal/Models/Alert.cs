using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalPatientPortal.Models
{
    public class Alert
    {
        public int AlertId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        [Required, MaxLength(100)]
        public string AlertType { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? Description { get; set; }

        [MaxLength(20)]
        public string? Severity { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
