using Microsoft.AspNetCore.Mvc;

namespace BestFoodWebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult AdminArea()
        {
            return View();
        }
    }
}
