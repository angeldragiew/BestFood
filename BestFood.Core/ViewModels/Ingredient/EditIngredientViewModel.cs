using System.ComponentModel.DataAnnotations;
using BestFood.Infrastructure.Enums;

namespace BestFood.Core.ViewModels.Ingredient
{
    public class EditIngredientViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ingredient name must be between 3 and 50 characters!")]
        [Display(Name = "Ingredient Name")]
        public string Name { get; set; }


        [EnumDataType(typeof(IngredientType), ErrorMessage = "Ingredient type is not valid!")]
        [Display(Name = "Ingredient Type")]
        public IngredientType Type { get; set; }


        [Display(Name = "Ingredient Categories")]
        public IList<int> CategoryIds { get; set; } = new List<int>();
    }
}
