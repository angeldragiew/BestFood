using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFood.Core.ViewModels.Product
{
    public class ProductReviewViewModel
    {
        public string ReviewId { get; set; }
        public string ReviewUsername { get; set; }
        public int ReviewRating { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}
