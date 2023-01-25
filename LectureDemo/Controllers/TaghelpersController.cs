using LectureDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureDemo.Controllers
{
    public class TaghelpersController : Controller
    {
        private MVC_DemoDbContext context;
        public TaghelpersController()
        {
            context = new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<Course> courses= context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            List<Instructor> instructors= context.Instructors.ToList();
            ViewBag.Instructors = new SelectList(instructors,"Id","Name");
            if(id == null)
            {
                return View("Error");
            }
            Course course = context.Courses.SingleOrDefault(c=>c.Id == id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
