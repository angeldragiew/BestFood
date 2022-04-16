using System.ComponentModel.DataAnnotations;

namespace BestFood.Core.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 50 characters!")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Category image is required!")]
        [Display(Name = "Category Image")]
        public string Image { get; set; }
    }
}
