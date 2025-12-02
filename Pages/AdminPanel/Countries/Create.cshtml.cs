using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Threading.Tasks;

namespace Quickunlocker.Web.Pages.AdminPanel.Countries
{
    public class CreateModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public CreateModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Country Country { get; set; } = new Country();

        public void OnGet()
        {
            // Initialize with defaults
            Country = new Country
            {
                IsActive = true,
                DisplayOrder = 0
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set timestamps
            Country.CreatedAt = DateTimeOffset.UtcNow;
            Country.IsDeleted = false;

            // Normalize code to uppercase
            Country.Code = Country.Code.ToUpper();

            _db.Countries.Add(Country);
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Country '{Country.Name}' created successfully!";

            return RedirectToPage("./Index");
        }
    }
}
