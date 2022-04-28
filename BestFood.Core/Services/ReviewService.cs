using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Review;
using BestFood.Infrastructure.Data.Models;
using BestFood.Infrastructure.Data.Repo;
using Microsoft.EntityFrameworkCore;

namespace BestFood.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<ApplicationUser> userRepo;
        private readonly IRepository<Review> reviewRepo;
        private readonly IRepository<Product> productRepo;

        public ReviewService(
            IRepository<ApplicationUser> userRepo,
            IRepository<Review> reviewRepo,
            IRepository<Product> productRepo)
        {
            this.userRepo = userRepo;
            this.reviewRepo = reviewRepo;
            this.productRepo = productRepo;
        }

        public async Task Delete(string id)
        {
            Review review = await reviewRepo.All().FirstOrDefaultAsync(r => r.Id == id);
            if (review == null)
            {
                throw new ArgumentNullException("Unknown review!");
            }
            reviewRepo.Delete(review);
            await reviewRepo.SaveChangesAsync();
        }

        public async Task EditAsync(EditReviewViewModel model)
        {
            Review review = await reviewRepo.All().FirstOrDefaultAsync(r => r.Id == model.Id);

            if (review == null)
            {
                throw new ArgumentNullException("Unknown review!");
            }

            review.Text = model.Text;
            review.Rating = model.Rating;

            await reviewRepo.SaveChangesAsync();
        }

        public async Task<EditReviewViewModel> FindByIdAsync(string id)
        {
            EditReviewViewModel review = await reviewRepo.All().Select(e => new EditReviewViewModel()
            {
                Id = e.Id,
                Text = e.Text,
                Rating = e.Rating,
                ProductId = e.ProductId
            }).FirstOrDefaultAsync(e => e.Id == id);

            if (review == null)
            {
                throw new ArgumentNullException("Unknown review!");
            }

            return review;

        }

        public async Task RateProdcutAsync(CreateReviewViewModel model, string username)
        {
            var user = userRepo
                           .All()
                           .FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new ArgumentNullException("Unknown user!");
            }

            if (productRepo.All().Any(p => p.Id == model.ProductId) == false)
            {
                throw new ArgumentNullException("Unknown product id!");
            }

            Review review = new Review()
            {
                ApplicationUserId = user.Id,
                Text = model.Text,
                Rating = model.Rating,
                ProductId = model.ProductId,
            };

            await reviewRepo.AddAsync(review);
            await reviewRepo.SaveChangesAsync();
        }
    }
}
