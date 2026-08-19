namespace ClinicalPatientPortal.Models.Dtos
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string? DocumentType { get; set; }
        public DateTime DocumentDate { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
