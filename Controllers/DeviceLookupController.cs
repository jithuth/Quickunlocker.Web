using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;

namespace Quickunlocker.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceLookupController : ControllerBase
    {
        private readonly DevicesDbContext _db;

        public DeviceLookupController(DevicesDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Lookup device details by IMEI.
        /// </summary>
        /// <param name="imei">IMEI number (15 digits)</param>
        /// <returns>Device details (if TAC found) or error message</returns>
        [HttpGet("lookup")]
        public async Task<IActionResult> Lookup([FromQuery] string imei)
        {
            if (string.IsNullOrWhiteSpace(imei) || imei.Length < 8)
                return BadRequest(new { error = "Invalid IMEI number" });

            if (!long.TryParse(imei.Substring(0, 8), out long tac))
                return BadRequest(new { error = "IMEI must be numeric" });

            var device = await _db.Devices.FirstOrDefaultAsync(d => d.Tac == tac);

            if (device == null)
                return NotFound(new { error = "Device not found for this TAC" });

            return Ok(new
            {
                device.Id,
                device.Tac,
                device.Brand,
                device.Model,
                device.BrandLogoUrl,
                device.CreatedAt
            });
        }


        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableBrandLogos()
        {
            var logos = await _db.Devices
                .Select(d => d.BrandLogoUrl)
                .ToListAsync();

            var uniqueLogos = logos
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Distinct()
                .OrderBy(l => l)
                .ToList();

            return Ok(uniqueLogos);
        }


    }
}
