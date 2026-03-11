using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using ProjetoFV.Models;
using ProjetoFV.Services;
using System.Diagnostics;
using ProjetoFV.Repositories;

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
		public IActionResult Profile()
		{
			return View();
		}
		public IActionResult Print()
		{
			return View();
		}
        public IActionResult Storage()
        {
            var product = _productService.GetAllProductPrice();
            return View(product);
        }
        public IActionResult AddStock(int id, double quantidade)
        {
            try
            {
                _productService.AddStock(id, quantidade);
                return RedirectToAction("Storage");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Storage");

            }
        }
        public IActionResult RemoveStock(int id, double quantidade)
        {
            try
            {
                _productService.RemoveStock(id, quantidade);
                return RedirectToAction("Storage");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Storage");
            }
        }
        public IActionResult Product()
        {
            var product = _productService.GetAllProductPrice();
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveCreate(string name, decimal price)
        {
            try
            {
                _productService.Create(name, price);
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create");
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, decimal price)
        {
            try
            {
                _productService.Update(id, name, price);
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
            }

            var model = new ProductModel
            {
                Id = id,
                Name = name,
                Price = price
                
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var product = _productService.GetById(id);

            if (product == null)
                return NotFound();

            return View(product);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            try
            {
                _productService.Delete(id);
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                ViewBag.Errors = ex.Message;
                return RedirectToAction("Product");
            }


        }

        
                
        
        
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
