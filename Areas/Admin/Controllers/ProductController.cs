using Microsoft.AspNetCore.Mvc;
using multiproj.DataAccess.Repository;
using multiproj.DataAccess.Repository.IRepository;
using multiproj.Models.Models;

namespace MultiProj.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allProducts=_unitOfWork.Product.GetAll().ToList();
            return View(allProducts);
        }
        [HttpGet]
        public IActionResult CreateProduct(int id) {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Product product = _unitOfWork.Product.GetValue(pr=>pr.ProductId==id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
