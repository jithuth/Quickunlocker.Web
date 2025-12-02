using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quickunlocker.Web.Pages.AdminPanel.Devices
{
    public class EditModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public EditModel(DevicesDbContext db)
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

            // IgnoreQueryFilters to get device even if soft-deleted (for admin view)
            Device = await _db.Devices
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (Device == null)
            {
                return NotFound();
            }

            // Don't allow editing deleted devices
            if (Device.IsDeleted)
            {
                TempData["ErrorMessage"] = "Cannot edit a deleted device.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var deviceToUpdate = await _db.Devices.FindAsync(Device.Id);

            if (deviceToUpdate == null)
            {
                return NotFound();
            }

            // Update properties
            deviceToUpdate.Tac = Device.Tac;
            deviceToUpdate.Brand = Device.Brand;
            deviceToUpdate.Model = Device.Model;
            deviceToUpdate.BrandLogoUrl = Device.BrandLogoUrl;
            deviceToUpdate.UpdatedAt = DateTimeOffset.UtcNow;

            try
            {
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Device updated successfully!";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Error updating device. Please try again.";
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
