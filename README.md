# Clinical Patient Portal

A web application for searching and viewing patient information.

## Technology Stack
- Backend: ASP.NET Core 8.0 (Razor Pages), C#, REST APIs
- Frontend: HTML5, CSS3, JavaScript / jQuery
- Database: SQL Server LocalDB, Entity Framework Core
- Authentication: ASP.NET Core Identity (Local Authentication)
- PDF Generation: QuestPDF

## Getting Started

No manual database setup is required. On first run, the application automatically creates the LocalDB database and seeds it with sample patient data via Entity Framework Core migrations.

1. Clone this repository.
2. Open `ClinicalPatientPortal.sln` in Visual Studio 2022.
3. Press F5 (or Ctrl+F5) to build and run.
4. The app creates and seeds `ClinicalPatientPortalDb` in `(localdb)\MSSQLLocalDB` automatically on startup.

Demo Account

A demo clinician account is seeded automatically on first run — no manual signup is required.

Email	doctor@clinicalportal.com
Password	Clinician123

## Features
- User Authentication (Login/Logout)
- Patient Search (MRN, DOB, First Name, Last Name) - paginated, with validation requiring at least one search field (the initial page load intentionally shows all patients before any search)
- Patient Demographics
- Allergies & Clinical Alerts
- Medications
- Documents (download)
- Print to PDF - Demographics, Allergies, Medications tabs call dedicated API endpoints that generate PDF files server-side using QuestPDF

## Architecture & API Layer

The app is split into two layers:

- Razor Pages (/Login, /Search, /PatientDetails/{id}) handle the UI and navigation. Page content — search results, demographics, allergies, medications, documents is populated client-side via JavaScript fetch calls to the REST API below.
- REST API (/api/patients/...) is organized as one controller per resource.

## Endpoint							
GET /api/patients/search : Search patients by MRN, DOB, first/last name (paginated)
GET /api/patients/{id} : Patient demographics
GET /api/patients/{id}/allergies : Patient allergies
GET /api/patients/{id}/alerts : Patient clinical alerts
GET /api/patients/{id}/medications : Patient medications
GET /api/patients/{id}/documents : List of documents on file
GET /api/patients/{id}/documents/{documentId}/download : Download a specific document
GET /api/patients/{id}/pdf/demographics : Generate demographics PDF
GET /api/patients/{id}/pdf/allergies : Generate allergies & alerts PDF
GET /api/patients/{id}/pdf/medications : Generate medications PDF

## Notes
All pages and all API endpoints require authentication by default, with the Login page as the exception.
Patient document files are stored outside wwwroot (in a PatientDocuments folder at the project root).


