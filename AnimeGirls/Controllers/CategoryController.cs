using Microsoft.AspNetCore.Mvc;

namespace AnimeGirls.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
