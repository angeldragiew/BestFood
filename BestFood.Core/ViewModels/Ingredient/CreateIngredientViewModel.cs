using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Enums;

namespace BestFood.Core.ViewModels.Ingredient
{
    public class CreateIngredientViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ingredient name must be between 3 and 50 characters!")]
        public string Name { get; set; }

        public IngredientType Type { get; set; }

        public IList<int> CategoryIds { get; set; } = new List<int>();
    }
}
