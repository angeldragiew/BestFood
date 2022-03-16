using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 50 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category image is required!")]
        public string Image { get; set; }
    }
}
