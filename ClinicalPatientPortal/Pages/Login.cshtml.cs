using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ClinicalPatientPortal.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter both email and password.";
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user, Password, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else if (result.IsLockedOut)
            {
                ErrorMessage = "Account locked due to multiple failed login attempts. Please try again later.";
            }
            else
            {
                ErrorMessage = "Invalid email or password.";
            }

            return Page();
        }
    }
}
