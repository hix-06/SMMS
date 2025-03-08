
using System.ComponentModel.DataAnnotations;

namespace SMMS.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
}
