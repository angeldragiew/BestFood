using System.ComponentModel.DataAnnotations;
using BestFood.Infrastructure.Enums;

namespace BestFood.Infrastructure.Data.Models
{
	public class Ingredient
	{
		[Key]
		[MaxLength(36)]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		public decimal Price { get; set; }

		public IngredientType Type { get; set; }

		public ICollection<ProductsIngredients> ProductsIngredients { get; set; } = new List<ProductsIngredients>();

		public ICollection<CategoriesIngredients> CategoriesIngredients { get; set; } = new List<CategoriesIngredients>();
	}
}
