using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Quickunlocker.Web.Pages.AdminPanel
{
    public class IndexModel : PageModel
    {
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }

        public void OnGet()
        {
            // Get session variables (set during login)
            UserEmail = HttpContext.Session.GetString("UserEmail") ?? "Unknown";
            IsAdmin = (HttpContext.Session.GetString("IsAdmin") == "1");
        }
    }
}
