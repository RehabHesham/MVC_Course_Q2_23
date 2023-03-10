using Layers_DI_Identity.Services;
using Layers_DI_Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Layers_DI_Identity.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult Index()
        {
            List<studentVM> studentVMs = studentService.GetAll();
            return View(studentVMs);
        }
    }
}
