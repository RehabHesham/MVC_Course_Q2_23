using Microsoft.AspNetCore.Mvc;

namespace LectureDemo.Controllers
{
    public class CustomValidationController : Controller
    {
        public IActionResult validateName(string Name, string Age)
        {
            if (Name.Contains("lala"))
            {
                if (Age.Contains("26"))
                {
                    return Json(true);
                }
               return  Json(false);
            }
            return   Json(true);
        }
    }
}
