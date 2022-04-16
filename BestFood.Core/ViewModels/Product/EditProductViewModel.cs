using System.ComponentModel.DataAnnotations;

namespace BestFood.Core.ViewModels.Product
{
    public class EditProductViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Product Name")]
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


        [Display(Name = "Product Category")]
        public int? CategoryId { get; set; }


        [Display(Name = "Product Ingredients")]
        public IList<string> IngredientIds { get; set; } = new List<string>();
    }
}
