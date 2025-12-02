using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quickunlocker.Web.Pages.AdminPanel.Networks
{
    public class IndexModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public IndexModel(DevicesDbContext db)
        {
            _db = db;
        }

        public List<Network> Networks { get; set; } = new();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string? Search { get; set; }
        public Guid? CountryFilter { get; set; }
        public int SerialStart { get; set; } = 1;
        public int TotalItems { get; set; }
        public List<Country> Countries { get; set; } = new();
        private const int PageSize = 10;

        public async Task<IActionResult> OnGetAsync([FromQuery] int? page, [FromQuery] string? search, [FromQuery] Guid? countryId)
        {
            CurrentPage = page ?? 1;
            Search = search ?? "";
            CountryFilter = countryId;

            // Load countries for filter dropdown
            Countries = await _db.Countries
                .Where(c => c.IsActive)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .ToListAsync();

            await LoadNetworksAsync();

            bool isAjax = Request.Headers.ContainsKey("X-Requested-With") &&
                          Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                return Partial("_NetworkTablePartial", this);
            }

            return Page();
        }

        private async Task LoadNetworksAsync()
        {
            if (CurrentPage < 1) CurrentPage = 1;
            Search = Search ?? "";

            IQueryable<Network> query = _db.Networks.Include(n => n.Country);

            // Apply country filter
            if (CountryFilter.HasValue && CountryFilter.Value != Guid.Empty)
            {
                query = query.Where(n => n.CountryId == CountryFilter.Value);
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(Search))
            {
                string searchLower = Search.ToLower();
                query = query.Where(n =>
                    n.Name.ToLower().Contains(searchLower) ||
                    n.Country!.Name.ToLower().Contains(searchLower));
            }

            TotalItems = await query.CountAsync();
            TotalPages = TotalItems > 0 ? (int)Math.Ceiling(TotalItems / (double)PageSize) : 1;

            if (CurrentPage > TotalPages)
                CurrentPage = TotalPages;

            SerialStart = ((CurrentPage - 1) * PageSize) + 1;

            Networks = await query
                .OrderBy(n => n.Country!.DisplayOrder)
                .ThenBy(n => n.DisplayOrder)
                .ThenBy(n => n.Name)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostToggleActiveAsync([FromQuery] Guid id)
        {
            var network = await _db.Networks.FindAsync(id);
            if (network != null)
            {
                network.IsActive = !network.IsActive;
                network.UpdatedAt = DateTimeOffset.UtcNow;
                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = $"Network '{network.Name}' is now {(network.IsActive ? "enabled" : "disabled")}.";
            }

            return RedirectToPage();
        }
    }
}
