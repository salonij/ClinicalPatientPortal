using System.ComponentModel.DataAnnotations;

namespace ClinicalPatientPortal.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required, MaxLength(20)]
        public string MRN { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DOB { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? AddressLine1 { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(20)]
        public string? State { get; set; }

        [MaxLength(10)]
        public string? ZipCode { get; set; }

        public ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();
        public ICollection<Medication> Medications { get; set; } = new List<Medication>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
    }
}
