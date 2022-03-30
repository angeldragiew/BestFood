using BestFood.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService=productService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
            var products = await productService.All(id);
            return View(products);
        }
    }
}
