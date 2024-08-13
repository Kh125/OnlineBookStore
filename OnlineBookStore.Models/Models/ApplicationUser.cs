using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Models.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public int Name { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }

        // Navigation property for orders
        public ICollection<Order> Orders { get; set; }
    }
}
