
using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Models;

namespace Quickunlocker.Web.Data
{
    public class DevicesDbContext : DbContext
    {
        public DevicesDbContext(DbContextOptions<DevicesDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
