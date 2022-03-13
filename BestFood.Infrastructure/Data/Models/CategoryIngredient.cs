using System.ComponentModel.DataAnnotations.Schema;

namespace BestFood.Infrastructure.Data.Models
{
    public class CategoryIngredient
	{
		public int CategoryId { get; set; }

		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; }


		public string IngredientId { get; set; }

		[ForeignKey(nameof(IngredientId))]
		public Ingredient Ingredient { get; set; }
	}
}
