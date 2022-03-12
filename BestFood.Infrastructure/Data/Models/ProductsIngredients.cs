using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Infrastructure.Data.Models
{
	public class ProductsIngredients
	{
		public string ProductId { get; set; }
		public Product Product { get; set; }

		public string IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }
	}
}
