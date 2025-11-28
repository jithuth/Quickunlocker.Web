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
            if (!ModelState.IsValid)
                return Page();

            // If password hashing is enabled later, uncomment this
            // var passwordHash = ComputeSha256Hash(Input.Password);

            var user = _db.Users.FirstOrDefault(u =>
                u.Email == Input.Email &&
                u.Password == Input.Password   // change to passwordHash later
            );

            if (user == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // ✅ Store session values
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "1" : "0");

            // ✅ Redirect based on role
            if (user.IsAdmin)
                return RedirectToPage("/AdminPanel/Index");   // Admin Dashboard
            else
                return RedirectToPage("/Index");         // Normal User Home
        }


        private static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
