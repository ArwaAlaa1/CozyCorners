using CozyCorners.Core;
using CozyCorners.Core.Models;
using CozyCorners.Core.Repositories.Contract;
using CozyCorners.Models;
using CozyCorners.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CozyCorners.Controllers
{
   //[Authorize(AuthenticationSchemes = "Cookies")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductRepository _product;

		public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork,IProductRepository product)
        {
            _logger = logger;
			_unitOfWork = unitOfWork;
			_product = product;
		}

        public async Task<IActionResult> Index()
        {
			var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
			var topCategories = categories.Take(3).ToList();
			var products = await _product.GetAllAsync();

			// Create ViewModel and populate data
			var model = new HomeViewModel
			{
				Categories = topCategories,
				Products = products
			};

			return View(model);

		}
	
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
