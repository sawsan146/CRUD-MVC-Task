using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models;
using MVC_CRUD.Services.Contract;
using MVC_CRUD.ViewModels;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        public IActionResult AddProduct()
        {

            return View("AddProduct");
        }
        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var res = _productService.AddProduct(product);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something went wrong while adding the product.");

            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
          

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View("UpdateProduct", product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductViewModel product)
        {
           
          
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var res = _productService.UpdateProduct(product);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something went wrong while updating the product.");
            return View(product);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var res = _productService.DeleteProductById(id);

            //if (!res)
            //{
            //    return NotFound();
            //}

            //return Content("Product deleted");

            return res ? RedirectToAction("Index") : NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
