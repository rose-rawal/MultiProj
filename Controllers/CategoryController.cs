using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace MultiProj.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _context.Categories.ToList();
            return View(categoryList);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            if (data.Name == data.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name cannot be same as order id");
                return View();
            }
            if (data != null) {
                _context.Categories.Add(data);
                _context.SaveChanges();
                TempData["success"] = "Successfully Created Category";
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id) {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var category=_context.Categories.FirstOrDefault(c=>c.CategoryId == id);
            if (category == null) {
                return NotFound();
            }
            return View(category); 
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["success"] = "Successfully Edited Category";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category=_context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Successfully Deleted Category";

            return RedirectToAction("Index");
        }

    }
}
