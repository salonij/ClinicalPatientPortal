using ClinicalPatientPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalPatientPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, MRN = "MRN1001", FirstName = "Jane", LastName = "Doe", DOB = new DateTime(1985, 4, 12), Gender = "Female", PhoneNumber = "555-123-4567", AddressLine1 = "123 Maple St", City = "Springfield", State = "IL", ZipCode = "62701" },
                new Patient { PatientId = 2, MRN = "MRN1002", FirstName = "John", LastName = "Smith", DOB = new DateTime(1978, 9, 23), Gender = "Male", PhoneNumber = "555-987-6543", AddressLine1 = "456 Oak Ave", City = "Springfield", State = "IL", ZipCode = "62702" },
                new Patient { PatientId = 3, MRN = "MRN1003", FirstName = "Emily", LastName = "Johnson", DOB = new DateTime(1992, 1, 30), Gender = "Female", PhoneNumber = "555-222-3333", AddressLine1 = "789 Pine Rd", City = "Springfield", State = "IL", ZipCode = "62703" },
                new Patient { PatientId = 4, MRN = "MRN1004", FirstName = "Michael", LastName = "Brown", DOB = new DateTime(1965, 7, 8), Gender = "Male", PhoneNumber = "555-333-1111", AddressLine1 = "12 Elm St", City = "Chicago", State = "IL", ZipCode = "60601" },
                new Patient { PatientId = 5, MRN = "MRN1005", FirstName = "Sarah", LastName = "Davis", DOB = new DateTime(2001, 11, 15), Gender = "Female", PhoneNumber = "555-444-2222", AddressLine1 = "88 Birch Blvd", City = "Chicago", State = "IL", ZipCode = "60602" },
                new Patient { PatientId = 6, MRN = "MRN1006", FirstName = "Robert", LastName = "Wilson", DOB = new DateTime(1955, 3, 22), Gender = "Male", PhoneNumber = "555-555-3333", AddressLine1 = "34 Cedar Ct", City = "Peoria", State = "IL", ZipCode = "61601" },
                new Patient { PatientId = 7, MRN = "MRN1007", FirstName = "Linda", LastName = "Martinez", DOB = new DateTime(1988, 6, 19), Gender = "Female", PhoneNumber = "555-666-4444", AddressLine1 = "56 Walnut Way", City = "Peoria", State = "IL", ZipCode = "61602" },
                new Patient { PatientId = 8, MRN = "MRN1008", FirstName = "David", LastName = "Anderson", DOB = new DateTime(1972, 12, 5), Gender = "Male", PhoneNumber = "555-777-5555", AddressLine1 = "90 Spruce Dr", City = "Naperville", State = "IL", ZipCode = "60540" },
                new Patient { PatientId = 9, MRN = "MRN1009", FirstName = "Patricia", LastName = "Thomas", DOB = new DateTime(1995, 8, 27), Gender = "Female", PhoneNumber = "555-888-6666", AddressLine1 = "21 Willow Ln", City = "Naperville", State = "IL", ZipCode = "60541" },
                new Patient { PatientId = 10, MRN = "MRN1010", FirstName = "James", LastName = "Taylor", DOB = new DateTime(1960, 2, 14), Gender = "Male", PhoneNumber = "555-999-7777", AddressLine1 = "67 Aspen Ave", City = "Aurora", State = "IL", ZipCode = "60505" }
            );

            modelBuilder.Entity<Allergy>().HasData(
                new Allergy { AllergyId = 1, PatientId = 1, AllergyName = "Penicillin", Severity = "Severe", Status = "Active", RecordedDate = new DateTime(2020, 3, 15) },
                new Allergy { AllergyId = 2, PatientId = 1, AllergyName = "Latex", Severity = "Moderate", Status = "Active", RecordedDate = new DateTime(2021, 6, 2) },
                new Allergy { AllergyId = 3, PatientId = 2, AllergyName = "Sulfa Drugs", Severity = "Mild", Status = "Active", RecordedDate = new DateTime(2019, 11, 20) },
                new Allergy { AllergyId = 4, PatientId = 3, AllergyName = "Peanuts", Severity = "Severe", Status = "Active", RecordedDate = new DateTime(2015, 5, 9) },
                new Allergy { AllergyId = 5, PatientId = 4, AllergyName = "Aspirin", Severity = "Moderate", Status = "Active", RecordedDate = new DateTime(2018, 8, 30) },
                new Allergy { AllergyId = 6, PatientId = 4, AllergyName = "Shellfish", Severity = "Mild", Status = "Resolved", RecordedDate = new DateTime(2016, 2, 11) },
                new Allergy { AllergyId = 7, PatientId = 6, AllergyName = "Iodine Contrast", Severity = "Severe", Status = "Active", RecordedDate = new DateTime(2022, 4, 4) },
                new Allergy { AllergyId = 8, PatientId = 7, AllergyName = "Codeine", Severity = "Moderate", Status = "Active", RecordedDate = new DateTime(2021, 9, 17) },
                new Allergy { AllergyId = 9, PatientId = 8, AllergyName = "Penicillin", Severity = "Mild", Status = "Active", RecordedDate = new DateTime(2020, 12, 1) },
                new Allergy { AllergyId = 10, PatientId = 10, AllergyName = "Latex", Severity = "Severe", Status = "Active", RecordedDate = new DateTime(2023, 3, 8) }
            );

            modelBuilder.Entity<Medication>().HasData(
                new Medication { MedicationId = 1, PatientId = 1, MedicationName = "Warfarin", Strength = "5mg", DosageInstructions = "Take one tablet daily", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2023, 1, 10), PrescribingProvider = "Dr. Alan Carter", Status = "Active" },
                new Medication { MedicationId = 2, PatientId = 1, MedicationName = "Metformin", Strength = "500mg", DosageInstructions = "Take twice daily with food", Frequency = "Twice daily", Route = "Oral", StartDate = new DateTime(2022, 5, 4), PrescribingProvider = "Dr. Alan Carter", Status = "Active" },
                new Medication { MedicationId = 3, PatientId = 2, MedicationName = "Lisinopril", Strength = "10mg", DosageInstructions = "Take one tablet daily", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2021, 8, 19), PrescribingProvider = "Dr. Susan Lee", Status = "Active" },
                new Medication { MedicationId = 4, PatientId = 3, MedicationName = "Albuterol Inhaler", Strength = "90mcg", DosageInstructions = "2 puffs as needed for wheezing", Frequency = "As needed", Route = "Inhalation", StartDate = new DateTime(2020, 6, 1), PrescribingProvider = "Dr. Karen Wu", Status = "Active" },
                new Medication { MedicationId = 5, PatientId = 4, MedicationName = "Atorvastatin", Strength = "20mg", DosageInstructions = "Take one tablet at bedtime", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2019, 3, 12), PrescribingProvider = "Dr. Alan Carter", Status = "Active" },
                new Medication { MedicationId = 6, PatientId = 4, MedicationName = "Amlodipine", Strength = "5mg", DosageInstructions = "Take one tablet daily", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2019, 3, 12), PrescribingProvider = "Dr. Alan Carter", Status = "Active" },
                new Medication { MedicationId = 7, PatientId = 5, MedicationName = "Sertraline", Strength = "50mg", DosageInstructions = "Take one tablet in the morning", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2023, 7, 2), PrescribingProvider = "Dr. Maria Gomez", Status = "Active" },
                new Medication { MedicationId = 8, PatientId = 6, MedicationName = "Metoprolol", Strength = "25mg", DosageInstructions = "Take one tablet twice daily", Frequency = "Twice daily", Route = "Oral", StartDate = new DateTime(2017, 10, 5), PrescribingProvider = "Dr. Susan Lee", Status = "Active" },
                new Medication { MedicationId = 9, PatientId = 6, MedicationName = "Furosemide", Strength = "20mg", DosageInstructions = "Take one tablet in the morning", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2018, 1, 22), PrescribingProvider = "Dr. Susan Lee", Status = "Active" },
                new Medication { MedicationId = 10, PatientId = 7, MedicationName = "Levothyroxine", Strength = "75mcg", DosageInstructions = "Take on an empty stomach each morning", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2021, 9, 17), PrescribingProvider = "Dr. Karen Wu", Status = "Active" },
                new Medication { MedicationId = 11, PatientId = 8, MedicationName = "Omeprazole", Strength = "20mg", DosageInstructions = "Take one capsule before breakfast", Frequency = "Once daily", Route = "Oral", StartDate = new DateTime(2022, 2, 14), PrescribingProvider = "Dr. Maria Gomez", Status = "Active" },
                new Medication { MedicationId = 12, PatientId = 9, MedicationName = "Ibuprofen", Strength = "400mg", DosageInstructions = "Take as needed for pain, max 3x daily", Frequency = "As needed", Route = "Oral", StartDate = new DateTime(2023, 5, 5), PrescribingProvider = "Dr. Alan Carter", Status = "Active" },
                new Medication { MedicationId = 13, PatientId = 10, MedicationName = "Insulin Glargine", Strength = "100 units/mL", DosageInstructions = "Inject 20 units subcutaneously at bedtime", Frequency = "Once daily", Route = "Subcutaneous", StartDate = new DateTime(2020, 11, 30), PrescribingProvider = "Dr. Susan Lee", Status = "Active" }
            );

            modelBuilder.Entity<Alert>().HasData(
                new Alert { AlertId = 1, PatientId = 1, AlertType = "Drug Allergy", Description = "Severe penicillin allergy - avoid penicillin-class antibiotics", Severity = "Critical", CreatedDate = new DateTime(2020, 3, 15) },
                new Alert { AlertId = 2, PatientId = 1, AlertType = "Bleeding Precaution", Description = "Patient on Warfarin - monitor for bleeding, check INR before procedures", Severity = "High", CreatedDate = new DateTime(2023, 1, 10) },
                new Alert { AlertId = 3, PatientId = 2, AlertType = "Fall Risk", Description = "History of falls - use bed alarm and non-slip footwear", Severity = "Medium", CreatedDate = new DateTime(2022, 2, 1) },
                new Alert { AlertId = 4, PatientId = 4, AlertType = "Cardiac Monitoring", Description = "Patient on statin + antihypertensive combination - monitor blood pressure regularly", Severity = "Medium", CreatedDate = new DateTime(2019, 3, 12) },
                new Alert { AlertId = 5, PatientId = 6, AlertType = "DNR", Description = "Confirmed Do Not Resuscitate order on file", Severity = "Critical", CreatedDate = new DateTime(2023, 6, 1) },
                new Alert { AlertId = 6, PatientId = 6, AlertType = "Fall Risk", Description = "Elderly patient with mobility issues - use walker, supervise transfers", Severity = "High", CreatedDate = new DateTime(2022, 9, 10) },
                new Alert { AlertId = 7, PatientId = 8, AlertType = "Isolation Precautions", Description = "Contact precautions - MRSA colonization on record", Severity = "Medium", CreatedDate = new DateTime(2021, 4, 18) },
                new Alert { AlertId = 8, PatientId = 10, AlertType = "Drug Allergy", Description = "Severe latex allergy - use latex-free equipment for all procedures", Severity = "High", CreatedDate = new DateTime(2023, 3, 8) }
            );

            modelBuilder.Entity<Document>().HasData(
                new Document { DocumentId = 1, PatientId = 1, DocumentName = "Consent Form.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2023, 1, 5), FilePath = "/documents/patient1/consent-form.pdf", UploadedDate = new DateTime(2023, 1, 5) },
                new Document { DocumentId = 2, PatientId = 1, DocumentName = "Lab Results.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2023, 6, 12), FilePath = "/documents/patient1/lab-results.pdf", UploadedDate = new DateTime(2023, 6, 12) },
                new Document { DocumentId = 3, PatientId = 2, DocumentName = "Referral Letter.docx", DocumentType = "Word Document", DocumentDate = new DateTime(2022, 11, 3), FilePath = "/documents/patient2/referral-letter.docx", UploadedDate = new DateTime(2022, 11, 3) },
                new Document { DocumentId = 4, PatientId = 3, DocumentName = "Immunization Record.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2021, 4, 20), FilePath = "/documents/patient3/immunization-record.pdf", UploadedDate = new DateTime(2021, 4, 20) },
                new Document { DocumentId = 5, PatientId = 4, DocumentName = "Discharge Summary.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2022, 7, 15), FilePath = "/documents/patient4/discharge-summary.pdf", UploadedDate = new DateTime(2022, 7, 15) },
                new Document { DocumentId = 6, PatientId = 5, DocumentName = "Insurance Card.jpg", DocumentType = "Image", DocumentDate = new DateTime(2023, 2, 9), FilePath = "/documents/patient5/insurance-card.jpg", UploadedDate = new DateTime(2023, 2, 9) },
                new Document { DocumentId = 7, PatientId = 6, DocumentName = "Advance Directive.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2023, 6, 1), FilePath = "/documents/patient6/advance-directive.pdf", UploadedDate = new DateTime(2023, 6, 1) },
                new Document { DocumentId = 8, PatientId = 7, DocumentName = "X-Ray Image.jpg", DocumentType = "Image", DocumentDate = new DateTime(2022, 10, 25), FilePath = "/documents/patient7/xray-image.jpg", UploadedDate = new DateTime(2022, 10, 25) },
                new Document { DocumentId = 9, PatientId = 8, DocumentName = "Progress Notes.docx", DocumentType = "Word Document", DocumentDate = new DateTime(2023, 4, 18), FilePath = "/documents/patient8/progress-notes.docx", UploadedDate = new DateTime(2023, 4, 18) },
                new Document { DocumentId = 10, PatientId = 9, DocumentName = "Consent Form.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2023, 5, 5), FilePath = "/documents/patient9/consent-form.pdf", UploadedDate = new DateTime(2023, 5, 5) },
                new Document { DocumentId = 11, PatientId = 10, DocumentName = "Lab Results.pdf", DocumentType = "PDF", DocumentDate = new DateTime(2023, 3, 8), FilePath = "/documents/patient10/lab-results.pdf", UploadedDate = new DateTime(2023, 3, 8) }
            );
        }
    }
}
