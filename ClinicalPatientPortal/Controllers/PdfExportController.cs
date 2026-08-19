using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ClinicalPatientPortal.Models;

namespace ClinicalPatientPortal.Controllers
{
    [ApiController]
    [Route("api/patients/{patientId}/pdf")]
    public class PdfExportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PdfExportController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("demographics")]
        public IActionResult ExportDemographics(int patientId)
        {
            var patient = GetPatient(patientId);
            if (patient == null) return NotFound();

            var pdfBytes = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Element(c => ComposeHeader(c, patient, "Demographics"));

                    page.Content().PaddingTop(15).Column(column =>
                    {
                        column.Spacing(8);
                        column.Item().Element(c => LabeledRow(c, "MRN", patient.MRN));
                        column.Item().Element(c => LabeledRow(c, "Date of Birth", patient.DOB.ToString("MM/dd/yyyy")));
                        column.Item().Element(c => LabeledRow(c, "Gender", patient.Gender));
                        column.Item().Element(c => LabeledRow(c, "Phone", patient.PhoneNumber ?? "-"));
                        column.Item().Element(c => LabeledRow(c, "Address",
                            $"{patient.AddressLine1}, {patient.City}, {patient.State} {patient.ZipCode}"));
                    });

                    page.Footer().Element(ComposeFooter);
                });
            }).GeneratePdf();

            return File(pdfBytes, "application/pdf", $"{patient.LastName}_{patient.FirstName}_Demographics.pdf");
        }

        [HttpGet("allergies")]
        public IActionResult ExportAllergiesAndAlerts(int patientId)
        {
            var patient = GetPatient(patientId);
            if (patient == null) return NotFound();

            var allergies = _context.Allergies.Where(a => a.PatientId == patientId).ToList();
            var alerts = _context.Alerts.Where(a => a.PatientId == patientId).ToList();

            var pdfBytes = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Element(c => ComposeHeader(c, patient, "Allergies & Alerts"));

                    page.Content().PaddingTop(15).Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Text("Allergies").FontSize(13).Bold().FontColor("#2563EB");
                        if (allergies.Count == 0)
                            column.Item().Text("No known allergies.").Italic().FontColor(Colors.Grey.Darken1);
                        else
                            column.Item().Element(c => AllergiesTable(c, allergies));

                        column.Item().PaddingTop(10).Text("Alerts").FontSize(13).Bold().FontColor("#2563EB");
                        if (alerts.Count == 0)
                            column.Item().Text("No active alerts.").Italic().FontColor(Colors.Grey.Darken1);
                        else
                            column.Item().Element(c => AlertsTable(c, alerts));
                    });

                    page.Footer().Element(ComposeFooter);
                });
            }).GeneratePdf();

            return File(pdfBytes, "application/pdf", $"{patient.LastName}_{patient.FirstName}_AllergiesAlerts.pdf");
        }

        [HttpGet("medications")]
        public IActionResult ExportMedications(int patientId)
        {
            var patient = GetPatient(patientId);
            if (patient == null) return NotFound();

            var medications = _context.Medications.Where(m => m.PatientId == patientId).ToList();

            var pdfBytes = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Element(c => ComposeHeader(c, patient, "Medications"));

                    page.Content().PaddingTop(15).Column(column =>
                    {
                        if (medications.Count == 0)
                            column.Item().Text("No medications on record.").Italic().FontColor(Colors.Grey.Darken1);
                        else
                            column.Item().Element(c => MedicationsTable(c, medications));
                    });

                    page.Footer().Element(ComposeFooter);
                });

            }).GeneratePdf();

            return File(pdfBytes, "application/pdf", $"{patient.LastName}_{patient.FirstName}_Medications.pdf");
        }

        private PatientDetailDto? GetPatient(int patientId)
        {
            return _context.Patients
                .Where(p => p.PatientId == patientId)
                .Select(p => new PatientDetailDto
                {
                    PatientId = p.PatientId,
                    MRN = p.MRN,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DOB = p.DOB,
                    Gender = p.Gender,
                    PhoneNumber = p.PhoneNumber,
                    AddressLine1 = p.AddressLine1,
                    City = p.City,
                    State = p.State,
                    ZipCode = p.ZipCode
                })
                .FirstOrDefault();
        }

        private static void ComposeHeader(IContainer container, PatientDetailDto patient, string sectionTitle)
        {
            container.Column(column =>
            {
                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Clinical Patient Portal").FontSize(18).Bold().FontColor("#2563EB");
                        col.Item().Text(sectionTitle).FontSize(14).SemiBold();
                    });
                    row.ConstantItem(160).AlignRight()
                        .Text($"Generated: {DateTime.Now:MM/dd/yyyy hh:mm tt}")
                        .FontSize(9).FontColor(Colors.Grey.Darken1);
                });

                column.Item().PaddingTop(8).PaddingBottom(8).LineHorizontal(1).LineColor("#2563EB");

                column.Item().Row(row =>
                {
                    row.RelativeItem().Text(t => { t.Span("Patient: ").SemiBold(); t.Span($"{patient.FirstName} {patient.LastName}"); });
                    row.RelativeItem().Text(t => { t.Span("MRN: ").SemiBold(); t.Span(patient.MRN); });
                    row.RelativeItem().Text(t => { t.Span("DOB: ").SemiBold(); t.Span(patient.DOB.ToString("MM/dd/yyyy")); });
                });
            });
        }

        private static void ComposeFooter(IContainer container)
        {
            container.AlignCenter()
            .DefaultTextStyle(x => x.FontSize(8).FontColor(Colors.Grey.Darken1))
            .Text(text =>
            {
                text.Span("Clinical Patient Portal - Confidential Patient Record - Page ");
                text.CurrentPageNumber();
                text.Span(" of ");
                text.TotalPages();
            });
        }

        private static void LabeledRow(IContainer container, string label, string value)
        {
            container.Row(row =>
            {
                row.ConstantItem(140).Text(label).SemiBold();
                row.RelativeItem().Text(value ?? "-");
            });
        }

        private static void AllergiesTable(IContainer container, List<Allergy> allergies)
        {
            container.Table(table => {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCell).Text("Allergen");
                    header.Cell().Element(HeaderCell).Text("Severity");
                    header.Cell().Element(HeaderCell).Text("Status");
                    header.Cell().Element(HeaderCell).Text("Recorded");
                });

                foreach (var a in allergies)
                {
                    table.Cell().Element(BodyCell).Text(a.AllergyName);
                    table.Cell().Element(BodyCell).Text(a.Severity ?? "-");
                    table.Cell().Element(BodyCell).Text(a.Status ?? "-");
                    table.Cell().Element(BodyCell).Text(a.RecordedDate.ToString("MM/dd/yyyy"));
                }
            });
        }

        private static void AlertsTable(IContainer container, List<Alert> alerts)
        {
            container.Table(table => {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCell).Text("Type");
                    header.Cell().Element(HeaderCell).Text("Description");
                    header.Cell().Element(HeaderCell).Text("Severity");
                    header.Cell().Element(HeaderCell).Text("Created");
                });

                foreach (var a in alerts)
                {
                    table.Cell().Element(BodyCell).Text(a.AlertType);
                    table.Cell().Element(BodyCell).Text(a.Description ?? "-");
                    table.Cell().Element(BodyCell).Text(a.Severity ?? "-");
                    table.Cell().Element(BodyCell).Text(a.CreatedDate.ToString("MM/dd/yyyy"));
                }
            });
        }

        private static void MedicationsTable(IContainer container, List<Medication> medications)
        {
            container.Table(table => {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(HeaderCell).Text("Medication");
                    header.Cell().Element(HeaderCell).Text("Dosage");
                    header.Cell().Element(HeaderCell).Text("Frequency");
                    header.Cell().Element(HeaderCell).Text("Start Date");
                    header.Cell().Element(HeaderCell).Text("Status");
                });

                foreach (var m in medications)
                {
                    table.Cell().Element(BodyCell).Text($"{m.MedicationName} {m.Strength}".Trim());
                    table.Cell().Element(BodyCell).Text(m.DosageInstructions ?? "-");
                    table.Cell().Element(BodyCell).Text(m.Frequency ?? "-");
                    table.Cell().Element(BodyCell).Text(m.StartDate.ToString("MM/dd/yyyy"));
                    table.Cell().Element(BodyCell).Text(m.Status ?? "-");
                }
            });
        }
        private static IContainer HeaderCell(IContainer container) =>
            container.DefaultTextStyle(x => x.SemiBold().FontColor(Colors.White))
                .Background("#2563EB").Padding(5);

        private static IContainer BodyCell(IContainer container) =>
            container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5);
    }
}
