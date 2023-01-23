using LectureDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LectureDemo.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult Index(string id)
        {
            return View("index",id);
        }

        public IActionResult ShowForm()
        {
            return View();
        }

        public IActionResult primitive(int age, string name)
        
        {
            TempData["primitive"] = $"name = {name}, age={age}";
            return RedirectToAction("Index");
        }

        public IActionResult UserDefined(Product product)
        {
            TempData["product"] = System.Text.Json.JsonSerializer.Serialize(product);
            return RedirectToAction("Index");
        }

        public IActionResult showCollectionform() {
            return View();
        }
        public IActionResult nested(Product product,[Bind(Prefix ="category")] Category categ)
        {
            TempData["product"] = System.Text.Json.JsonSerializer.Serialize(product);
            TempData["category"] = System.Text.Json.JsonSerializer.Serialize(categ);

            return RedirectToAction("Index");
        }

        public IActionResult ArrayTest(List<string> Data)
        {
            TempData["data"] = System.Text.Json.JsonSerializer.Serialize(Data);
            return RedirectToAction("Index");
        }

        public IActionResult DictionaryTest(Dictionary<string, string> Data,[FromForm]List<Product> products)
        {
            TempData["data"] = System.Text.Json.JsonSerializer.Serialize(Data);
            return RedirectToAction("Index");
        }

    }
}
