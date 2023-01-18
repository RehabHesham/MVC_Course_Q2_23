using Microsoft.AspNetCore.Mvc;
using Day_1.Models;

namespace Day_1.Controllers
{
    public class ProductController : Controller
    {
        public ContentResult Index()
        {
            //ContentResult result = new();
            //result.Content = "Welcome to our website from product controller";
            //return result;

            return Content("Welcome to our website from product controller");
        }

        public JsonResult Product() 
        {
            //JsonResult result = new JsonResult(new { Id = 1, name = "Car", price = 1000 });
            //return result;

            return Json(new { Id = 1, name = "Car", price = 1000 });
        }

        public EmptyResult ServerAction()
        {
            //EmptyResult result = new EmptyResult();
            //return result;

            return Empty;
        }

        public ViewResult ProductDetails()
        {
            return View("details");
        }

        public IActionResult GetProduct()
        {
            //return Json( new Product()
            //{
            //    Id= 1,
            //    price= 1000,
            //    Name = "Car",
            //    Description = "This is a car"
            //});


            Product product = new Product()
            {
                Id = 1,
                price = 2000,
                Name = "Car",
                Description = "This is a car"
            };

            return View("productDetails",product);
        }


        public IActionResult GetAllProducts()
        {
            List<Product> products = SampleData.Products;
            return View("GetAll",products);
        }

        public IActionResult AddForm()
        {
            return View("AddForm");
        }

        public IActionResult AddData(Product product) { 
            SampleData.AddProduct(product);


            List<Product> products = SampleData.Products.Where(p => p.price > 200).ToList();
            if(products.Count > 0) {
            return View("GetAll", products);
            }
            else
            {
                return Content("No products available");
            }
        }

    }
}
