using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;

namespace Quickunlocker.Web.Pages.AdminPanel.Devices
{
    public class CreateModel : PageModel
    {
        private readonly DevicesDbContext _db;
        [BindProperty]
        public Device Device { get; set; }
        public CreateModel(DevicesDbContext db) => _db = db;

        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _db.Devices.Add(Device);
            _db.SaveChanges();
            return RedirectToPage("/AdminPanel/Devices/Index");
        }
    }
}
