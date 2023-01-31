using Layers_DI_Identity.Models;
using Layers_DI_Identity.Reposiotries;
using Layers_DI_Identity.ViewModels;
using System.Runtime.CompilerServices;

namespace Layers_DI_Identity.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public List<studentVM> GetAll()
        {
            List<Student> students = studentRepo.GetAll();

            List<studentVM> studentVMs = new List<studentVM>();
            foreach (var std in students)
            {
                studentVMs.Add(new studentVM()
                {
                    Id = std.Id,
                    Name = std.Name,
                    Age = std.Age,
                });
            }
            return studentVMs;
        }

        public studentVM GetById(int id)
        {
            Student student = studentRepo.GetById(id);
            studentVM studentVM = new()
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
            };
            return studentVM;
        }
    }
}
