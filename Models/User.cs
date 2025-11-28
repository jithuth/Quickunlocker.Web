namespace Quickunlocker.Web.Models
{
    // Models/User.cs
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }  // Store only hash!

        [Required, Phone]
        public string WhatsApp { get; set; }
        public bool IsAdmin { get; set; }

    }


}
