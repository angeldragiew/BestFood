using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Името на категорията е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името на категорията трябва да е между 3 и 50 символа!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Снимката на категорията е задължителна")]
        public string Image { get; set; }
    }
}
