using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quickunlocker.Web.Pages.AdminPanel.Networks
{
    public class EditModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public EditModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Network Network { get; set; }

        public List<SelectListItem> CountryOptions { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Network = await _db.Networks
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(n => n.Id == id);

            if (Network == null)
                return NotFound();

            if (Network.IsDeleted)
            {
                TempData["ErrorMessage"] = "Cannot edit a deleted network.";
                return RedirectToPage("./Index");
            }

            await LoadCountriesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCountriesAsync();
                return Page();
            }

            var networkToUpdate = await _db.Networks.FindAsync(Network.Id);

            if (networkToUpdate == null)
                return NotFound();

            networkToUpdate.Name = Network.Name;
            networkToUpdate.LogoUrl = Network.LogoUrl;
            networkToUpdate.CountryId = Network.CountryId;
            networkToUpdate.DisplayOrder = Network.DisplayOrder;
            networkToUpdate.IsActive = Network.IsActive;
            networkToUpdate.UpdatedAt = DateTimeOffset.UtcNow;

            try
            {
                await _db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Network updated successfully!";
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "Error updating network. Please try again.";
                await LoadCountriesAsync();
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadCountriesAsync()
        {
            var countries = await _db.Countries
                .Where(c => c.IsActive)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .ToListAsync();

            CountryOptions = countries.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}
