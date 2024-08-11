using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineBookStore.Models.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Genre { get; set; }

        public int Stock { get; set; }

        public int RemainingStock { get; set; }

        // Optional: URL to cover image
        [Url]
        public string? CoverImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
