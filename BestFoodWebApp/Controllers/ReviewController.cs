using BestFood.Core.Constants;
using BestFood.Core.Services.Contracts;
using BestFood.Core.ViewModels.Review;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {

        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> RateProduct(CreateReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = String.Join(", ", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                TempData[MessageConstant.ErrorMessage] = errorMessage;
                return RedirectToAction("Details", "Product", new { id = model.ProductId });
            }

            try
            {
                await reviewService.RateProdcutAsync(model, User.Identity.Name);
                TempData[MessageConstant.SuccessMessage] = "Review added successfully!";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Could not add the review!";
            }
            return RedirectToAction("Details", "Product", new { id = model.ProductId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string reviewId, string productId)
        {
            try
            {
                EditReviewViewModel model = await reviewService.FindByIdAsync(reviewId);
                return PartialView("_EditReviewPartial", model);
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
                return RedirectToAction("Details", "Product", new { id = productId });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = String.Join(", ", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                TempData[MessageConstant.ErrorMessage] = errorMessage;
                return RedirectToAction("Details", "Product", new { id = model.ProductId });
            }

            try
            {
                await reviewService.EditAsync(model);
                TempData[MessageConstant.SuccessMessage] = "Review editted successfully!";
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }

            return RedirectToAction("Details", "Product", new { id = model.ProductId });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string reviewId, string productId)
        {
            try
            {
                await reviewService.Delete(reviewId);
                TempData[MessageConstant.SuccessMessage] = "Review deleted successfully!";
            }
            catch (ArgumentNullException ex)
            {
                TempData[MessageConstant.ErrorMessage] = ex.Message;
            }
            return RedirectToAction("Details", "Product", new { id = productId });
        }

    }
}
