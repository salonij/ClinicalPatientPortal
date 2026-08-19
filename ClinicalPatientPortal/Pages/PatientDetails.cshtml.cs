using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClinicalPatientPortal.Pages
{
    public class PatientDetailsModel : PageModel
    {
        public int PatientId { get; set; }
        public IActionResult OnGet(int id)
        {
            if (id <= 0)
            {
                return RedirectToPage("/Search");
            }

            PatientId = id;
            return Page();
        }
    }
}
