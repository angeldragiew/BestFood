using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Product;
using BestFood.Core.ViewModels.Review;
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
        private readonly IRepository<ProductIngredient> productIngredientRepo;
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<Review> reviewRepo;

        public ProductService(IRepository<Category> categoryRepo,
            IRepository<Ingredient> ingredientRepo,
            IRepository<Product> productRepo,
            IRepository<ProductIngredient> productIngredientRepo,
            IRepository<ApplicationUser> userRepo,
            IRepository<Review> reviewRepo)
        {
            this.categoryRepo = categoryRepo;
            this.ingredientRepo = ingredientRepo;
            this.productRepo = productRepo;
            this.productIngredientRepo = productIngredientRepo;
            this.userRepo = userRepo;
            this.reviewRepo = reviewRepo;
        }

        public async Task<IEnumerable<ProductViewModel>> All(int id)
        {
            return await productRepo
                .All()
                .Where(p => p.CategoryId == id)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Image = p.Image,
                }).ToListAsync();
        }


        public async Task<ProductDetailsViewModel> Details(string id)
        {
            var product = await productRepo
                 .All()
                 .Select(p=> new ProductDetailsViewModel()
                 {
                     Id = p.Id,
                     Name = p.Name,
                     WeightInGrams = p.WeightInGrams,
                     Price = p.Price,
                     Image = p.Image,
                     CategoryId = p.Category.Id,
                     IngredientsNames = p.ProductsIngredients.Select(pi => pi.Ingredient.Name).ToList(),
                     Reviews = p.Reviews.Select(r => new ProductReviewViewModel()
                     {
                         ReviewId = r.Id,
                         ReviewUsername = r.ApplicationUser.UserName,
                         ReviewRating = r.Rating,
                         Date = r.Date.ToString("d"),
                         Text = r.Text
                     }).ToList()
                 })
                 .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException("Unknown product");
            }

            return product;
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

        public async Task Delete(string id)
        {
            Product product = await productRepo
                .All()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentException("Unknown ingredient!");
            }

            productRepo.Delete(product);
            await productRepo.SaveChangesAsync();
        }

        public async Task EditAsync(EditProductViewModel model)
        {
            Product product = await productRepo.All().FirstOrDefaultAsync(p => p.Id == model.Id);

            if (product == null)
            {
                throw new ArgumentNullException("Unknown product!");
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.WeightInGrams = model.WeightInGrams;
            product.Image = model.Image;

            productIngredientRepo.DeleteRange(productIngredientRepo
                                                .All()
                                                .Where(pi => pi.ProductId == model.Id));

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

            await productRepo.SaveChangesAsync();
        }

        public async Task<EditProductViewModel> FindById(string id)
        {
            EditProductViewModel ingredient = await productRepo.All().Select(p => new EditProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                WeightInGrams = p.WeightInGrams,
                Image = p.Image,
                Price = p.Price,
                CategoryId = p.CategoryId,
                IngredientIds = p.ProductsIngredients.Select(pc => pc.IngredientId).ToArray()
            }).FirstOrDefaultAsync(e => e.Id == id);

            if (ingredient == null)
            {
                throw new ArgumentException("Unknown ingredient!");
            }

            return ingredient;
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

        public async Task<IEnumerable<ProductIngredientViewModel>> LoadIngredients(int id, string productId)
        {
            return await ingredientRepo
                .All()
                .Where(i => i.CategoryIngredients.Any(i => i.Category.Id == id))
                .Select(i => new ProductIngredientViewModel()
                {
                    IngredientId = i.Id,
                    IngredientName = i.Name,
                    IsSelected = i.ProductIngredients.Any(pi => pi.ProductId == productId && pi.IngredientId == i.Id)
                })
                .ToListAsync();
        }

        public async Task RateProdcutAsync(CreateReviewViewModel model, string username)
        {
            Review review = new Review()
            {
                ApplicationUserId = userRepo
                                    .All()
                                    .FirstOrDefault(u => u.UserName == username).Id,
                Text = model.Text,
                Rating = model.Rating,
                ProductId = model.ProductId,
            };

            await reviewRepo.AddAsync(review);
            await reviewRepo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductReviewViewModel>> LoadReviewsForProduct(string productId)
        {
            return await reviewRepo
                .All()
                .Select(r => new ProductReviewViewModel()
                {
                    ReviewId = r.Id,
                    ReviewUsername = r.ApplicationUser.UserName,
                    ReviewRating = r.Rating,
                    Date = r.Date.ToString("d"),
                    Text = r.Text
                }).ToListAsync();
        }
    }
}
