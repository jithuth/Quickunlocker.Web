using System;
using System.ComponentModel.DataAnnotations;

namespace Quickunlocker.Web.Models
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public long Tac { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string BrandLogoUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
