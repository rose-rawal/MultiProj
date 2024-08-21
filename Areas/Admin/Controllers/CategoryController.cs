using Microsoft.AspNetCore.Mvc;
using multiproj.DataAccess.Repository.IRepository;
using multiProj.DataAccess.Data;
using multiProj.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace MultiProj.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _unitOfWork.Category.GetAll().ToList();
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
            if (data != null)
            {
                _unitOfWork.Category.Add(data);
                _unitOfWork.Save();
                TempData["success"] = "Successfully Created Category";
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var category = _unitOfWork.Category.GetValue(u => u.CategoryId == id);
            if (category == null)
            {
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
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
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
            Category? category = _unitOfWork.Category.GetValue(u => u.CategoryId == id);
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
            Category? category = _unitOfWork.Category.GetValue(u => u.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Successfully Deleted Category";

            return RedirectToAction("Index");
        }

    }
}
