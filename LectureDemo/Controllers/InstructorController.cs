using LectureDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectureDemo.Controllers
{
    public class InstructorController : Controller
    {
        private MVC_DemoDbContext dbContext;
        public InstructorController()
        {
            dbContext = new MVC_DemoDbContext();
        }
        public IActionResult InsCourses(int id)
        {
            Instructor ins = dbContext.Instructors.Include(i => i.Courses).SingleOrDefault(i=>i.Id == id);
            List<Course> courses = ins.Courses;
            return View();
        }
    }
}
