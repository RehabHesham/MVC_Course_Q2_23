using LectureDemo.Models;
using LectureDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LectureDemo.Controllers
{
    public class StdCrsController : Controller
    {
        private MVC_DemoDbContext db;
        public StdCrsController()
        {
            db = new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<StudentCourse> students = db.StudentCourses.Include(sc=>sc.std).Include(sc=>sc.crs).ToList();

            return View(students);
        }

        public IActionResult AddStudentCourse()
        {
            //List<Student> students = db.Students.ToList();
            //List<Course> courses = db.Courses.ToList();
            //ViewBag.students = students;
            //ViewBag.courses = courses;

            StudentCourseVM studentCourseVM = new StudentCourseVM()
            {
                students = db.Students.ToList(),
                courses = db.Courses.ToList()
            };
            return View(studentCourseVM);
        }

        //public IActionResult AddToDb(StudentCourse studentCourse)
        public IActionResult AddToDb(StudentCourseVM studentCourseVM)

        {
            StudentCourse? studentCrs = db.StudentCourses.SingleOrDefault(sc=> (sc.StdId == studentCourseVM.StdId) && (sc.CrsId == studentCourseVM.CrsId));
            if (studentCrs == null)
            {
                StudentCourse studentCourse = new StudentCourse()
                {
                    StdId = studentCourseVM.StdId,
                    CrsId = studentCourseVM.CrsId,
                };
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
             return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(AddStudentCourse));
        }
    }
}
