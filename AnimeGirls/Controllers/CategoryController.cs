using AnimeGirls.Data;
using AnimeGirls.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimeGirls.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objectList = _db.Category;
            return View(objectList);
        }
    }
}
