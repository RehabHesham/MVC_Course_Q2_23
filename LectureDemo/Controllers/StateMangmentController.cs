using Microsoft.AspNetCore.Mvc;

namespace LectureDemo.Controllers
{
    public class StateMangmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TempDatatest()
        {
            return View();
        }

        public IActionResult SaveTempData(string msg)
        {
            TempData["msg"] = msg;
            return RedirectToAction("Index");
        }

        public IActionResult CookiesTest()
        {
            string msg = Request.Cookies["msg"];
            return View("CookiesTest", msg);
        }

        public IActionResult SaveCookie(string msg)
        {
            Response.Cookies.Append("msg", msg);

            CookieOptions options = new CookieOptions()
            {
                Expires= DateTime.Now.AddDays(1),
                Secure= true,
            };
            Response.Cookies.Append("Emsg", msg, options);
            return  RedirectToAction(nameof(Index));
        }

        public IActionResult SessionTest()
        {
            string msg = HttpContext.Session.GetString("msg");
            return View("SessionTest", msg);
        }

        public IActionResult SaveSession(string msg)
        {
            HttpContext.Session.SetString("msg", msg);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClearAll()
        {
            //HttpContext.Session.Remove("msg");
            HttpContext.Session.Clear();

            Response.Cookies.Delete("msg");
            Response.Cookies.Delete("Emsg");

            return RedirectToAction(nameof(Index));
        }
    }
}
