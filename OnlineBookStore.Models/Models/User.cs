using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Models.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; }

        public ICollection<int> Roles { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public string Address { get; set; }

        // Navigation property for orders
        public ICollection<Order> Orders { get; set; }
    }
}