using LectureDemo.Models;
using LectureDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LectureDemo.Controllers
{
    public class validationStdController : Controller
    {
        MVC_DemoDbContext context;

        public validationStdController()
        {
    context= new MVC_DemoDbContext();
        }
        public IActionResult Index()
        {
            List<Student> students = context.Students.ToList();
            return View(students);
        }

        public IActionResult Details(int? id)
        {
            if(id == null) return View("Error");
            Student? student = context.Students.Include(s => s.StudentCourses).ThenInclude(sc => sc.crs).SingleOrDefault(s => s.Id == id);
            if(student == null) return View("Error");
            return View(student);
        }

        [HttpGet]
        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(StudentVM student)
        {
            //if(ModelState.GetFieldValidationState("Name") == ModelValidationState.Valid
            //    && student.Name.Contains("lala"))
            //{
            //    ModelState.AddModelError("Name", "lala i not a valid name.");
            //}
            if(ModelState.GetFieldValidationState("Name") == ModelValidationState.Valid 
                && ModelState.GetFieldValidationState("Age") == ModelValidationState.Valid
                && student.Name.Contains("ali") && !(int.Parse(student.Age) >= 25))
            {
                ModelState.AddModelError("", "Student ali must be older than 25 years old.");
            }
            if(ModelState.IsValid) {
                Student newStudent = new Student()
                {
                    Name = student.Name,
                    Age = student.Age,
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [NonAction]
        public IActionResult result()
        {
            return Json(context);
        }
    }
}
