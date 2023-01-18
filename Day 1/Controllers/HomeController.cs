using Microsoft.AspNetCore.Mvc;

namespace Day_1.Controllers
{
    public class HomeController : Controller
    {
        public ContentResult Index()
        {
            ContentResult result = new();
            result.Content = "Welcome to our website from home controller";
            return result;
        }

        public ViewResult Welcome()
        {
            return View("Hello");
        }

        public IActionResult Vary(int id)
        {
            if(id == 9) return Content("Test1");
            else return Json(new { status= "Test2" });
        }
    }
}
