using Microsoft.AspNetCore.Mvc;
using ProjetoFV.Models;
using ProjetoFV.Services;
using System.Diagnostics;

namespace ProjetoFV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService priceService)
        {
            _logger = logger;
            _productService = priceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Storage()
        {
            return View();
        }

        public IActionResult Product()
        {
            var product = _productService.GetAllProductPrice();
            return View(product);
        }
		public IActionResult Profile()
		{
			return View();
		}
		public IActionResult Print()
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
