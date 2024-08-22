using Microsoft.AspNetCore.Mvc;
using multiproj.DataAccess.Repository;
using multiproj.DataAccess.Repository.IRepository;

namespace MultiProj.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            var allProducts=_unitOfWork.Product.GetAll().ToList();
            return View(allProducts);
        }
    }
}
