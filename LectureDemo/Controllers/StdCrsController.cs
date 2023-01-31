using LectureDemo.Models;
using LectureDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public IActionResult EditStdGrade()
        {
            List<Student> students = db.Students.ToList();
            ViewBag.Students = new SelectList(students,"Id","Name");
            return View();
        }

        public IActionResult EditStdGrade_std(int id)
        {
            //var courses = db.Courses.Include(c => c.studentCrs)
            //    .SelectMany(c => c.studentCrs, (crs, std_crs) => new {crs.Id, std_crs.StdId, crs.Name})
            //    .Where(c=>c.StdId == id).ToList();

            List<Course> courses = db.StudentCourses.Include(sc => sc.crs)
                .Where(sc => sc.StdId == id).Select(sc => sc.crs).ToList();

            ViewBag.courses = new SelectList(courses, "Id", "Name");

            StudentCourse studentCourse = new StudentCourse()
            {
                grade = courses.Count > 0?db.StudentCourses.SingleOrDefault(sc => (sc.StdId == id) && (sc.CrsId == courses[0].Id)).grade : 0,
            };
            return PartialView("_CoursesList", studentCourse);
        }

        public IActionResult EditStdGrade_stdCrs(int id,int crsId)
        {
            StudentCourse? studentCourse = db.StudentCourses.SingleOrDefault(sc => sc.StdId == id && sc.CrsId == crsId);
            if (studentCourse == null) return View("Error");
            return PartialView("_grade",studentCourse);
        }
        [HttpPost]
        public IActionResult EditStdGrade(StudentCourse studentCourse)
        {
            db.StudentCourses.Update(studentCourse);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
