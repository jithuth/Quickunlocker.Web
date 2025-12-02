using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System;

namespace Quickunlocker.Web.Pages.AdminPanel.Devices
{
    public class CreateModel : PageModel
    {
        private readonly DevicesDbContext _db;
        
        [BindProperty]
        public Device Device { get; set; }
        
        public CreateModel(DevicesDbContext db) => _db = db;

        public void OnGet() 
        {
            // Initialize empty device
            Device = new Device();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
                return Page();
            
            // Set timestamps
            Device.CreatedAt = DateTimeOffset.UtcNow;
            Device.IsDeleted = false;
            
            _db.Devices.Add(Device);
            _db.SaveChanges();
            
            TempData["SuccessMessage"] = $"Device '{Device.Brand} {Device.Model}' created successfully!";
            
            return RedirectToPage("/AdminPanel/Devices/Index");
        }
    }
}
