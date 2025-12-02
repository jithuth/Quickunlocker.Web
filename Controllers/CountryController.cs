using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Data;
using Quickunlocker.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Quickunlocker.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly DevicesDbContext _db;

        public CountryController(DevicesDbContext db)
        {
            _db = db;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCountries()
        {
            var countries = await _db.Countries
                .Where(c => c.IsActive)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    id = c.Id,
                    name = c.Name,
                    code = c.Code,
                    flagUrl = c.FlagUrl
                })
                .ToListAsync();

            return Ok(countries);
        }
    }
}
