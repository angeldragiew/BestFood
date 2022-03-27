using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsSelected { get; set; }

    }
}
