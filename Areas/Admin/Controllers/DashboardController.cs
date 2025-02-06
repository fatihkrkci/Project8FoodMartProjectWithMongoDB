using Microsoft.AspNetCore.Mvc;

namespace Project8FoodMartProjectWithMongoDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
