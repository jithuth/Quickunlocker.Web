using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models; // Make sure you have a User model here
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Quickunlocker.Web.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly DevicesDbContext _db;

        public AuthController(DevicesDbContext db) => _db = db;

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new { success = false, message = "Email and password are required." });

            var hash = ComputeSha256Hash(req.Password);

            // Replace 'User' with your actual User entity name if needed
            var user = _db.Users.FirstOrDefault(u => u.Email == req.Email && u.Password == hash);
            if (user == null)
                return Unauthorized(new { success = false, message = "Invalid email or password." });

            // Session (use only if session is enabled)
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "1" : "0");

            return Ok(new { success = true, isAdmin = user.IsAdmin, redirectUrl = "/AdminPanel/Index" });
        }

        // Utility: SHA256 Hash
        public static string ComputeSha256Hash(string rawData)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
