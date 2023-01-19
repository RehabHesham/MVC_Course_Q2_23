using LectureDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LectureDemo.Controllers
{
    public class CourseController : Controller
    {
        private MVC_DemoDbContext dbContext;
        public CourseController()
        {
            dbContext= new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<Course> courses = dbContext.Courses.ToList();
            return View(courses);
        }

        public IActionResult GetById(int id)
        {
            Course? course = dbContext.Courses.SingleOrDefault(c => c.Id == id);
            if(course == null)
            {
                return View("Error"); // view : Error , model = null
            }
            return View(course);  // view : GetById , model = course


            //return View();    // view : GetById , model = null
            //return View("GetOne", course);  // view : GetOne , model = Course
        }

        public IActionResult Add()
        {
            List<Instructor> instructors = dbContext.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult AddCourseDb(Course course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();

            List<Course> courses = dbContext.Courses.ToList();
            return View("Index",courses);
        }

        public IActionResult Edit(int id)
        {
            Course course = dbContext.Courses.SingleOrDefault(c => c.Id == id);
            List<Instructor> instructors = dbContext.Instructors.ToList();
            ViewBag.ins = instructors;
            return View(course);
        }
        
        public IActionResult EditCourseDb(Course course)
        {
            Course oldCourse = dbContext.Courses.SingleOrDefault(c => c.Id == course.Id);
            oldCourse.Name = course.Name;
            oldCourse.Description = course.Description;
            oldCourse.hours = course.hours;
            oldCourse.InstructorId = course.InstructorId;
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Course course = dbContext.Courses.SingleOrDefault(c => c.Id == id);
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
