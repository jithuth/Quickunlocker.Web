using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Threading.Tasks;

namespace Quickunlocker.Web.Pages.AdminPanel.Networks
{
    public class DeleteModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public DeleteModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Network Network { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Network = await _db.Networks
                .Include(n => n.Country)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (Network == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Network = await _db.Networks.FindAsync(id);

            if (Network != null)
            {
                // Soft delete
                Network.IsDeleted = true;
                Network.DeletedAt = DateTimeOffset.UtcNow;
                
                await _db.SaveChangesAsync();
                
                TempData["SuccessMessage"] = $"Network '{Network.Name}' deleted successfully!";
            }

            return RedirectToPage("./Index");
        }
    }
}
