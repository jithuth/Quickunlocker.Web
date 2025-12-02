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
    public class CreateModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public CreateModel(DevicesDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Network Network { get; set; } = new Network();

        public List<SelectListItem> CountryOptions { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadCountriesAsync();
            Network = new Network
            {
                IsActive = true,
                DisplayOrder = 0
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCountriesAsync();
                return Page();
            }

            Network.CreatedAt = DateTimeOffset.UtcNow;
            Network.IsDeleted = false;

            _db.Networks.Add(Network);
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Network '{Network.Name}' created successfully!";

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
