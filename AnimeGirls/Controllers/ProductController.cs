using AnimeGirls.Data;
using AnimeGirls.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AnimeGirls.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objectList = _db.Product;

            foreach (var obj in objectList)
            {
                obj.Category = _db.Category.FirstOrDefault(x => x.Id == obj.CategoryId);
            }
            return View(objectList);
        }

        //GET UPSERT
        public IActionResult Upsert(int? id)
        {
            Product product = new Product();
            if (id is null)
            {
                //This is for create
                return View(product);
            }
            else
            {
                product = _db.Product.Find(id);
                if (product is null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }

        //POST UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Update(product);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(product);
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Add(product);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(product);
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Product product = _db.Product.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }

        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Product product = _db.Product.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            _db.Product.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
