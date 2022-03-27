using System.ComponentModel.DataAnnotations;
using BestFood.Infrastructure.Data.Models;

namespace BestFood.Core.ViewModels.Product
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name="Product Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Product Weight")]
        public int WeightInGrams { get; set; }


        [Required]
        [Display(Name = "Product Image")]
        public string Image { get; set; }


        [Required]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }


        [Display(Name ="Product Category")]
        public int CategoryId { get; set; }


        [Display(Name = "Product Ingredients")]
        public IList<int> IngredientIds { get; set; } = new List<int>();
    }
}
