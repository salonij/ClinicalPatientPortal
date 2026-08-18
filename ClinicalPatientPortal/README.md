# Clinical Patient Portal

A web application for searching and viewing patient information, built for the R2657612 Clinical Systems Analyst Assessment.

## Technology Stack
- **Backend:** ASP.NET Core 8.0 (Razor Pages), C#, REST APIs
- **Frontend:** HTML5, CSS3, JavaScript / jQuery
- **Database:** SQL Server LocalDB, Entity Framework Core
- **Authentication:** ASP.NET Core Identity (Local Authentication)

## Getting Started

No manual database setup is required. On first run, the application automatically creates the LocalDB database and seeds it with sample patient data via Entity Framework Core migrations.

1. Clone this repository.
2. Open `ClinicalPatientPortal.sln` in Visual Studio 2022.
3. Press **F5** (or Ctrl+F5) to build and run.
4. The app creates and seeds `ClinicalPatientPortalDb` in `(localdb)\MSSQLLocalDB` automatically on startup.

## Features
- [ ] User Authentication (Login/Logout)
- [ ] Patient Search (MRN, DOB, First Name, Last Name)
- [ ] Patient Demographics
- [ ] Allergies & Clinical Alerts
- [ ] Medications
- [ ] Documents (view/open)
- [ ] Print to PDF (Demographics, Allergies, Medications)
- [ ] REST API Layer
