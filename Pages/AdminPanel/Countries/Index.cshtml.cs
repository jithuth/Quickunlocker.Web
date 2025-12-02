using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Quickunlocker.Web.Pages.AdminPanel.Countries
{
    public class IndexModel : PageModel
    {
        private readonly DevicesDbContext _db;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(DevicesDbContext db, ILogger<IndexModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public List<Country> Countries { get; set; } = new();
        
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string? Search { get; set; }
        public int SerialStart { get; set; } = 1;
        public int TotalItems { get; set; }
        private const int PageSize = 10; // Changed from 20 to 10

        public IActionResult OnGet([FromQuery] int? page, [FromQuery] string? search)
        {
            CurrentPage = page ?? 1;
            Search = search ?? "";
            
            LoadCountries();
            
            // Check if it's an AJAX request
            bool isAjax = Request.Headers.ContainsKey("X-Requested-With") && 
                          Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            
            if (isAjax)
            {
                return Partial("_CountryTablePartial", this);
            }
            
            return Page();
        }

        private void LoadCountries()
        {
            if (CurrentPage < 1) CurrentPage = 1;
            Search = Search ?? "";

            IQueryable<Country> query = _db.Countries;

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(Search))
            {
                string searchLower = Search.ToLower();
                query = query.Where(c =>
                    c.Name.ToLower().Contains(searchLower) ||
                    c.Code.ToLower().Contains(searchLower));
            }

            // Get total count
            TotalItems = query.Count();
            TotalPages = TotalItems > 0 ? (int)System.Math.Ceiling(TotalItems / (double)PageSize) : 1;

            // Ensure CurrentPage doesn't exceed TotalPages
            if (CurrentPage > TotalPages)
                CurrentPage = TotalPages;

            // Calculate serial start
            SerialStart = ((CurrentPage - 1) * PageSize) + 1;

            // Get paginated countries
            Countries = query
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        public async Task<IActionResult> OnPostToggleActiveAsync([FromQuery] Guid id)
        {
            var country = await _db.Countries.FindAsync(id);
            if (country != null)
            {
                country.IsActive = !country.IsActive;
                country.UpdatedAt = DateTimeOffset.UtcNow;
                await _db.SaveChangesAsync();
                
                TempData["SuccessMessage"] = $"Country '{country.Name}' is now {(country.IsActive ? "enabled" : "disabled")}.";
            }
            
            return RedirectToPage();
        }
    }
}
