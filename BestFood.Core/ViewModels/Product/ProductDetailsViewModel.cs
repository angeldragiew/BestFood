namespace BestFood.Core.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int WeightInGrams { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public IList<string> IngredientsNames { get; set; }

        public IList<ProductReviewViewModel> Reviews { get; set; }
    }
}
