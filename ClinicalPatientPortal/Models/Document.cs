using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicalPatientPortal.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient? Patient { get; set; }

        [Required, MaxLength(200)]
        public string DocumentName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? DocumentType { get; set; }

        public DateTime DocumentDate { get; set; }

        [Required, MaxLength(500)]
        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadedDate { get; set; }
    }
}
