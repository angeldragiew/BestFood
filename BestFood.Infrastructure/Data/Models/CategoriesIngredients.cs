using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Infrastructure.Data.Models
{
	public class CategoriesIngredients
	{
		public int CategoryId { get; set; }
		public Category Category { get; set; }

		public string IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }
	}
}
