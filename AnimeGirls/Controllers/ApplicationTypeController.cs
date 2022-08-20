using AnimeGirls.Data;
using AnimeGirls.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimeGirls.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objectList = _db.ApplicationType;
            return View(objectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType type)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Add(type);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(type);
        }

        //GET Edit
        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            ApplicationType applicationType = _db.ApplicationType.Find(id);
            if (applicationType is null)
            {
                return NotFound();
            }
            return View(applicationType);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(applicationType);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(applicationType);
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            ApplicationType applicationType = _db.ApplicationType.Find(id);
            if (applicationType is null)
            {
                return NotFound();
            }
            return View(applicationType);
        }

        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            ApplicationType applicationType = _db.ApplicationType.Find(id);
            if (applicationType is null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(applicationType);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
