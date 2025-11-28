using Microsoft.AspNetCore.Mvc;
using Quickunlocker.Web.Data;
using System.Security.Cryptography;
using System.Text;

[Route("auth")]
public class AuthController : Controller
{
    private readonly DevicesDbContext _db;
    public AuthController(DevicesDbContext db) => _db = db;

    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        var hash = ComputeSha256Hash(password);
        var user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == hash);
        if (user == null)
            return Unauthorized("Invalid email or password");

        // Set session/cookie as per your logic
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("UserEmail", user.Email);
        HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "1" : "0");

        return Ok(new { success = true, isAdmin = user.IsAdmin });
    }

    public static string ComputeSha256Hash(string rawData)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}
