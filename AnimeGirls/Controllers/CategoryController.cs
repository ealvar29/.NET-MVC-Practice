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

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //GET Edit
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Category category = _db.Category.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(category);
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(category);
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Category category = _db.Category.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Category category = _db.Category.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            _db.Category.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
