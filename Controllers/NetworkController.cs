using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Quickunlocker.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkController : ControllerBase
    {
        private readonly DevicesDbContext _db;

        public NetworkController(DevicesDbContext db)
        {
            _db = db;
        }

        [HttpGet("by-country/{countryCode}")]
        public async Task<IActionResult> GetNetworksByCountry(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                return BadRequest("Country code is required");

            // Find country by code
            var country = await _db.Countries
                .Where(c => c.Code == countryCode.ToUpper() && c.IsActive)
                .FirstOrDefaultAsync();

            if (country == null)
                return NotFound("Country not found or inactive");

            // Get networks for the country
            var networks = await _db.Networks
                .Where(n => n.CountryId == country.Id && n.IsActive)
                .OrderBy(n => n.DisplayOrder)
                .ThenBy(n => n.Name)
                .Select(n => new
                {
                    id = n.Id,
                    name = n.Name,
                    logoUrl = n.LogoUrl
                })
                .ToListAsync();

            return Ok(networks);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveNetworks()
        {
            var networks = await _db.Networks
                .Include(n => n.Country)
                .Where(n => n.IsActive && n.Country!.IsActive)
                .OrderBy(n => n.Country!.DisplayOrder)
                .ThenBy(n => n.DisplayOrder)
                .ThenBy(n => n.Name)
                .Select(n => new
                {
                    id = n.Id,
                    name = n.Name,
                    logoUrl = n.LogoUrl,
                    countryCode = n.Country!.Code,
                    countryName = n.Country.Name
                })
                .ToListAsync();

            return Ok(networks);
        }
    }
}
