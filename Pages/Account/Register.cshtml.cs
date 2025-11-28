using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quickunlocker.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly DevicesDbContext _context;
        public RegisterModel(DevicesDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [MinLength(6)]
            public string Password { get; set; }
            [Required]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
            [Required]
            public string WhatsApp { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please fix validation errors";
                return Page();
            }

            var exists = await _context.Users.AnyAsync(u => u.Email == Input.Email);
            if (exists)
            {
                ErrorMessage = "Email already registered.";
                return Page();
            }

            var user = new User
            {
                Email = Input.Email,
                Password = Input.Password, // For demo only! Hash in production
                WhatsApp = Input.WhatsApp,
                IsAdmin = false
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            SuccessMessage = "Registration successful! You can login now.";
            return RedirectToPage("/Account/Login");
        }
    }
}
