using CozyCorners.Core;
using CozyCorners.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CozyCorners.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
  

        public CategoryController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
          
        }
        public async  Task<IActionResult> Index()
        {
           var categories=await _unitOfWork.Repository<Category>().GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{

        //}


    }
}
