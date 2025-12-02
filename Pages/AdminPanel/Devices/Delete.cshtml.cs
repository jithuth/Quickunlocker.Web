using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quickunlocker.Web.Pages.AdminPanel.Devices
{
    public class DeleteModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public DeleteModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _db.Devices.FirstOrDefaultAsync(d => d.Id == id);

            if (Device == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Device = await _db.Devices.FindAsync(id);

            if (Device != null)
            {
                // Soft delete: Mark as deleted instead of removing from database
                Device.IsDeleted = true;
                Device.DeletedAt = DateTimeOffset.UtcNow;
                
                await _db.SaveChangesAsync();
                
                TempData["SuccessMessage"] = $"Device '{Device.Brand} {Device.Model}' deleted successfully!";
            }

            return RedirectToPage("./Index");
        }
    }
}
