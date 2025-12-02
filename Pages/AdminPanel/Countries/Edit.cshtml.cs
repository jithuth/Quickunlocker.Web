using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quickunlocker.Web.Pages.AdminPanel.Countries
{
    public class EditModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public EditModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Country = await _db.Countries
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (Country == null)
                return NotFound();

            if (Country.IsDeleted)
            {
                TempData["ErrorMessage"] = "Cannot edit a deleted country.";
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var countryToUpdate = await _db.Countries.FindAsync(Country.Id);

            if (countryToUpdate == null)
                return NotFound();

            countryToUpdate.Name = Country.Name;
            countryToUpdate.Code = Country.Code.ToUpper();
            countryToUpdate.FlagUrl = Country.FlagUrl;
            countryToUpdate.DisplayOrder = Country.DisplayOrder;
            countryToUpdate.IsActive = Country.IsActive;
            countryToUpdate.UpdatedAt = DateTimeOffset.UtcNow;

            try
            {
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Country updated successfully!";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Error updating country. Please try again.";
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
