using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using System.Security.Cryptography;
using System.Text;

namespace Quickunlocker.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly DevicesDbContext _db;
        public LoginModel(DevicesDbContext db) => _db = db;

        [BindProperty]
        public InputModel Input { get; set; }
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            //var passwordHash = ComputeSha256Hash(Input.Password);

            var user = _db.Users.FirstOrDefault(u => u.Email == Input.Email && u.Password == Input.Password);
            if (user == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // Simple login: set session or cookie
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "1" : "0");

            // Redirect to dashboard or home
            return RedirectToPage("/Index");
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
