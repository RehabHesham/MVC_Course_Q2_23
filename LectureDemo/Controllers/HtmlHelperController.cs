using LectureDemo.Models;
using LectureDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectureDemo.Controllers
{
    public class HtmlHelperController : Controller
    {
        private MVC_DemoDbContext context;
        public HtmlHelperController()
        {
            context= new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
           
            return View(instructors);
        }

        public IActionResult Add()
        {
            List<Course> courses = context.Courses.ToList();
            ViewBag.courses = new SelectList(courses, "Id", "Name");
            return View();
        }
        public IActionResult AddDb(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) {
            Instructor ins = context.Instructors.SingleOrDefault(i => i.Id== id);
            List<Course> courses = context.Courses.ToList();
            //ViewBag.courses = new SelectList(courses, "Id", "Name");

            insVM vM = new()
            {
                Id = ins.Id,
                Name = ins.Name,
                Age= ins.Age,
                Salary= ins.Salary,
                crsId = 2,
                courses = new SelectList(courses, "Id", "Name")
            };
            return View(vM);
        }

        public IActionResult EditDb(Instructor instructor)
        {
            context.Instructors.Update(instructor);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
