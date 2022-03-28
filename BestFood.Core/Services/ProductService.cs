using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Product;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<Ingredient> ingredientRepo;
        private readonly IRepository<Product> productRepo;

        public ProductService(IRepository<Category> categoryRepo,
            IRepository<Ingredient> ingredientRepo,
            IRepository<Product> productRepo)
        {
            this.categoryRepo = categoryRepo;
            this.ingredientRepo = ingredientRepo;
            this.productRepo = productRepo;
        }

        public async Task<IEnumerable<ProductViewModel>> All()
        {
            return await productRepo
                .All()
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    WeightInGrams = p.WeightInGrams,
                    Price = p.Price,
                    Image = p.Image,
                    CategoryId = p.Category.Id,
                    IngredientsNames = p.ProductsIngredients.Select(pi => pi.Ingredient.Name).ToList(),
                    Reviews = p.Reviews.Select(r=>new ProductReviewViewModel()
                    {
                        ReviewId=r.Id,
                        ReviewUsername = r.ApplicationUser.UserName,
                        ReviewRating = r.Rating,
                        Date=r.Date.ToString("d"),
                        Text=r.Text
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<bool> CategoryExists(int id)
        {
            return await categoryRepo
                .All()
                .AnyAsync(c => c.Id == id);
        }

        public async Task CreateAsync(CreateProductViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                WeightInGrams = model.WeightInGrams,
                Image = model.Image,
                CategoryId = model.CategoryId,
            };

            foreach (var id in model.IngredientIds)
            {
                if (ingredientRepo.All().Any(i => i.Id == id))
                {
                    product.ProductsIngredients.Add(new ProductIngredient()
                    {
                        Product = product,
                        IngredientId = id
                    });
                }
            }

            await productRepo.AddAsync(product);
            await productRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> LoadCategoriesForCreate()
        {
            return await categoryRepo
                .All()
                .Select(c => new ProductCategoryViewModel()
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                    IsSelected = false
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id)
        {
            return await ingredientRepo
                .All()
                .Where(i => i.CategoryIngredients.Any(i => i.Category.Id == id))
                .Select(i => new ProductIngredientViewModel()
                {
                    IngredientId = i.Id,
                    IngredientName = i.Name,
                    IsSelected = false
                })
                .ToListAsync();
        }


    }
}
