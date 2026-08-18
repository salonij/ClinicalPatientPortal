using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicalPatientPortal.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AddressLine1", "City", "DOB", "FirstName", "Gender", "LastName", "MRN", "PhoneNumber", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Maple St", "Springfield", new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Female", "Doe", "MRN1001", "555-123-4567", "IL", "62701" },
                    { 2, "456 Oak Ave", "Springfield", new DateTime(1978, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Male", "Smith", "MRN1002", "555-987-6543", "IL", "62702" },
                    { 3, "789 Pine Rd", "Springfield", new DateTime(1992, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Female", "Johnson", "MRN1003", "555-222-3333", "IL", "62703" },
                    { 4, "12 Elm St", "Chicago", new DateTime(1965, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Male", "Brown", "MRN1004", "555-333-1111", "IL", "60601" },
                    { 5, "88 Birch Blvd", "Chicago", new DateTime(2001, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Female", "Davis", "MRN1005", "555-444-2222", "IL", "60602" },
                    { 6, "34 Cedar Ct", "Peoria", new DateTime(1955, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Male", "Wilson", "MRN1006", "555-555-3333", "IL", "61601" },
                    { 7, "56 Walnut Way", "Peoria", new DateTime(1988, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linda", "Female", "Martinez", "MRN1007", "555-666-4444", "IL", "61602" },
                    { 8, "90 Spruce Dr", "Naperville", new DateTime(1972, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Male", "Anderson", "MRN1008", "555-777-5555", "IL", "60540" },
                    { 9, "21 Willow Ln", "Naperville", new DateTime(1995, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patricia", "Female", "Thomas", "MRN1009", "555-888-6666", "IL", "60541" },
                    { 10, "67 Aspen Ave", "Aurora", new DateTime(1960, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Male", "Taylor", "MRN1010", "555-999-7777", "IL", "60505" }
                });

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "AlertId", "AlertType", "CreatedDate", "Description", "PatientId", "Severity" },
                values: new object[,]
                {
                    { 1, "Drug Allergy", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Severe penicillin allergy - avoid penicillin-class antibiotics", 1, "Critical" },
                    { 2, "Bleeding Precaution", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient on Warfarin - monitor for bleeding, check INR before procedures", 1, "High" },
                    { 3, "Fall Risk", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "History of falls - use bed alarm and non-slip footwear", 2, "Medium" },
                    { 4, "Cardiac Monitoring", new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient on statin + antihypertensive combination - monitor blood pressure regularly", 4, "Medium" },
                    { 5, "DNR", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed Do Not Resuscitate order on file", 6, "Critical" },
                    { 6, "Fall Risk", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elderly patient with mobility issues - use walker, supervise transfers", 6, "High" },
                    { 7, "Isolation Precautions", new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contact precautions - MRSA colonization on record", 8, "Medium" },
                    { 8, "Drug Allergy", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Severe latex allergy - use latex-free equipment for all procedures", 10, "High" }
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergyId", "AllergyName", "PatientId", "RecordedDate", "Severity", "Status" },
                values: new object[,]
                {
                    { 1, "Penicillin", 1, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Severe", "Active" },
                    { 2, "Latex", 1, new DateTime(2021, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderate", "Active" },
                    { 3, "Sulfa Drugs", 2, new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mild", "Active" },
                    { 4, "Peanuts", 3, new DateTime(2015, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Severe", "Active" },
                    { 5, "Aspirin", 4, new DateTime(2018, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderate", "Active" },
                    { 6, "Shellfish", 4, new DateTime(2016, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mild", "Resolved" },
                    { 7, "Iodine Contrast", 6, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Severe", "Active" },
                    { 8, "Codeine", 7, new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moderate", "Active" },
                    { 9, "Penicillin", 8, new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mild", "Active" },
                    { 10, "Latex", 10, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Severe", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentId", "DocumentDate", "DocumentName", "DocumentType", "FilePath", "PatientId", "UploadedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consent Form.pdf", "PDF", "/documents/patient1/consent-form.pdf", 1, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lab Results.pdf", "PDF", "/documents/patient1/lab-results.pdf", 1, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Referral Letter.docx", "Word Document", "/documents/patient2/referral-letter.docx", 2, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Immunization Record.pdf", "PDF", "/documents/patient3/immunization-record.pdf", 3, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discharge Summary.pdf", "PDF", "/documents/patient4/discharge-summary.pdf", 4, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Insurance Card.jpg", "Image", "/documents/patient5/insurance-card.jpg", 5, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advance Directive.pdf", "PDF", "/documents/patient6/advance-directive.pdf", 6, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "X-Ray Image.jpg", "Image", "/documents/patient7/xray-image.jpg", 7, new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Progress Notes.docx", "Word Document", "/documents/patient8/progress-notes.docx", 8, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consent Form.pdf", "PDF", "/documents/patient9/consent-form.pdf", 9, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lab Results.pdf", "PDF", "/documents/patient10/lab-results.pdf", 10, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicationId", "DosageInstructions", "EndDate", "Frequency", "MedicationName", "PatientId", "PrescribingProvider", "Route", "StartDate", "Status", "Strength" },
                values: new object[,]
                {
                    { 1, "Take one tablet daily", null, "Once daily", "Warfarin", 1, "Dr. Alan Carter", "Oral", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "5mg" },
                    { 2, "Take twice daily with food", null, "Twice daily", "Metformin", 1, "Dr. Alan Carter", "Oral", new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "500mg" },
                    { 3, "Take one tablet daily", null, "Once daily", "Lisinopril", 2, "Dr. Susan Lee", "Oral", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "10mg" },
                    { 4, "2 puffs as needed for wheezing", null, "As needed", "Albuterol Inhaler", 3, "Dr. Karen Wu", "Inhalation", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "90mcg" },
                    { 5, "Take one tablet at bedtime", null, "Once daily", "Atorvastatin", 4, "Dr. Alan Carter", "Oral", new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "20mg" },
                    { 6, "Take one tablet daily", null, "Once daily", "Amlodipine", 4, "Dr. Alan Carter", "Oral", new DateTime(2019, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "5mg" },
                    { 7, "Take one tablet in the morning", null, "Once daily", "Sertraline", 5, "Dr. Maria Gomez", "Oral", new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "50mg" },
                    { 8, "Take one tablet twice daily", null, "Twice daily", "Metoprolol", 6, "Dr. Susan Lee", "Oral", new DateTime(2017, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "25mg" },
                    { 9, "Take one tablet in the morning", null, "Once daily", "Furosemide", 6, "Dr. Susan Lee", "Oral", new DateTime(2018, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "20mg" },
                    { 10, "Take on an empty stomach each morning", null, "Once daily", "Levothyroxine", 7, "Dr. Karen Wu", "Oral", new DateTime(2021, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "75mcg" },
                    { 11, "Take one capsule before breakfast", null, "Once daily", "Omeprazole", 8, "Dr. Maria Gomez", "Oral", new DateTime(2022, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "20mg" },
                    { 12, "Take as needed for pain, max 3x daily", null, "As needed", "Ibuprofen", 9, "Dr. Alan Carter", "Oral", new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "400mg" },
                    { 13, "Inject 20 units subcutaneously at bedtime", null, "Once daily", "Insulin Glargine", 10, "Dr. Susan Lee", "Subcutaneous", new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "100 units/mL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "AlertId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumn: "AllergyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "DocumentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "MedicationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 10);
        }
    }
}
