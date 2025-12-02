using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quickunlocker.Web.Pages.AdminPanel
{
    public class DiagnosticModel : PageModel
    {
        private readonly DevicesDbContext _db;

        public DiagnosticModel(DevicesDbContext db)
        {
            _db = db;
        }

        public int TotalDevices { get; set; }
        public int ExpectedPages { get; set; }
        public int SoftDeletedCount { get; set; }
        public List<Device> SampleDevices { get; set; } = new();

        public void OnGet()
        {
            // Get total active devices (not soft-deleted)
            TotalDevices = _db.Devices.Count();

            // Calculate expected pages (10 per page)
            ExpectedPages = TotalDevices > 0 ? (int)System.Math.Ceiling(TotalDevices / 10.0) : 0;

            // Get soft-deleted count
            SoftDeletedCount = _db.Devices
                .IgnoreQueryFilters()
                .Count(d => d.IsDeleted);

            // Get sample devices
            SampleDevices = _db.Devices
                .OrderByDescending(d => d.CreatedAt)
                .Take(10)
                .ToList();
        }
    }
}
