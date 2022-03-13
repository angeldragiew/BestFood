using System.ComponentModel.DataAnnotations.Schema;

namespace BestFood.Infrastructure.Data.Models
{
    public class ProductIngredient
	{
		public string ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; }


		public string IngredientId { get; set; }

		[ForeignKey(nameof(IngredientId))]
		public Ingredient Ingredient { get; set; }
	}
}
