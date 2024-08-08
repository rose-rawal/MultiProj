using Microsoft.AspNetCore.Mvc;
using MultiProj.Data;
using MultiProj.Models;

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
                return BadRequest();
            }
            if(data != null) {
                _context.Categories.Add(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
    }
}
