using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.Ingredient
{
    public class CategoryCheckBoxViewModel
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsSelected { get; set; }

        
    }
}
