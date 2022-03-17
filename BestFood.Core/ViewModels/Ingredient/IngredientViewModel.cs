using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Enums;

namespace BestFood.Core.ViewModels.Ingredient
{
    public class IngredientViewModel
    {
		public string Id { get; set; } = Guid.NewGuid().ToString();

		public string Name { get; set; }


		public IngredientType Type { get; set; }

		public ICollection<string> CategoryNames { get; set; } = new List<string>();
	}
}
