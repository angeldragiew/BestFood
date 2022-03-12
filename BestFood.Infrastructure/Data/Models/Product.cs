using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestFood.Infrastructure.Data.Models
{
	public class Product
    {
        [Key]
        [MaxLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public int WeightInGrams { get; set; }


        [Required]
        public string Image { get; set; }

        public decimal Price { get; set; }


        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<ProductsIngredients> ProductsIngredients { get; set; } = new List<ProductsIngredients>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
	}
}
