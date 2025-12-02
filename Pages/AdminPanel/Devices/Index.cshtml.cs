using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Quickunlocker.Web.Pages.AdminPanel.Devices
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

        public List<Device> Devices { get; set; } = new();
        
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string? Search { get; set; }
        public int SerialStart { get; set; } = 1;
        public int TotalItems { get; set; }
        private const int PageSize = 10;

        public IActionResult OnGet([FromQuery] int? page, [FromQuery] string? search)
        {
            // Log raw parameters
            _logger.LogInformation("========================================");
            _logger.LogInformation("OnGet CALLED - Raw Parameters:");
            _logger.LogInformation("  page parameter: {Page}", page?.ToString() ?? "NULL");
            _logger.LogInformation("  search parameter: {Search}", search ?? "NULL");
            _logger.LogInformation("  Query String: {QueryString}", Request.QueryString.ToString());
            _logger.LogInformation("========================================");
            
            // Set properties from parameters
            CurrentPage = page ?? 1;
            Search = search ?? "";
            
            LoadDevices();
            
            // Check if it's an AJAX request
            bool isAjax = Request.Headers.ContainsKey("X-Requested-With") && 
                          Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            
            _logger.LogInformation("Is AJAX request: {IsAjax}", isAjax);
            
            if (isAjax)
            {
                _logger.LogInformation("Returning partial view with {Count} devices", Devices.Count);
                return Partial("_DeviceTablePartial", this);
            }
            
            _logger.LogInformation("Returning full page with {Count} devices", Devices.Count);
            return Page();
        }

        private void LoadDevices()
        {
            // Ensure valid page number
            if (CurrentPage < 1) CurrentPage = 1;
            Search = Search ?? "";

            _logger.LogInformation("LoadDevices - CurrentPage: {CurrentPage}, Search: '{Search}'", CurrentPage, Search);

            // Global query filter automatically excludes soft-deleted devices
            IQueryable<Device> query = _db.Devices;

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(Search))
            {
                string searchLower = Search.ToLower();
                query = query.Where(d =>
                    d.Brand.ToLower().Contains(searchLower) ||
                    d.Model.ToLower().Contains(searchLower) ||
                    d.Tac.ToString().Contains(Search));
                
                _logger.LogInformation("Search filter applied for: '{Search}'", Search);
            }

            // Get total count
            TotalItems = query.Count();
            TotalPages = TotalItems > 0 ? (int)System.Math.Ceiling(TotalItems / (double)PageSize) : 1;

            _logger.LogInformation("Total items: {TotalItems}, Total pages: {TotalPages}", TotalItems, TotalPages);

            // Ensure CurrentPage doesn't exceed TotalPages
            if (CurrentPage > TotalPages)
            {
                CurrentPage = TotalPages;
                _logger.LogInformation("CurrentPage adjusted to: {CurrentPage}", CurrentPage);
            }

            // Calculate serial start
            SerialStart = ((CurrentPage - 1) * PageSize) + 1;

            // Get paginated devices
            Devices = query
                .OrderByDescending(d => d.CreatedAt)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            
            _logger.LogInformation("Loaded {Count} devices for page {Page}", Devices.Count, CurrentPage);
        }
    }
}
