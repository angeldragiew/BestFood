using System.ComponentModel.DataAnnotations;

namespace BestFood.Infrastructure.Data.Models
{
	public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<CategoryIngredient> CategoriesIngredients { get; set; } = new List<CategoryIngredient>();
    }
}
