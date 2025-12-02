using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quickunlocker.Web.Pages.AdminPanel.Countries
{
    public class DeleteModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public DeleteModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Country = await _db.Countries.FirstOrDefaultAsync(c => c.Id == id);

            if (Country == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Country = await _db.Countries.FindAsync(id);

            if (Country != null)
            {
                // Soft delete
                Country.IsDeleted = true;
                Country.DeletedAt = DateTimeOffset.UtcNow;
                
                await _db.SaveChangesAsync();
                
                TempData["SuccessMessage"] = $"Country '{Country.Name}' deleted successfully!";
            }

            return RedirectToPage("./Index");
        }
    }
}
