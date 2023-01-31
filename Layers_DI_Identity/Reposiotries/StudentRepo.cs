using Layers_DI_Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace Layers_DI_Identity.Reposiotries
{
    public class StudentRepo : IStudentRepo
    {
        private MVC_DemoDbContext context;
        public StudentRepo(MVC_DemoDbContext dbContext)
        {
            this.context = dbContext;
        }

        public List<Student> GetAll()
        {
            //List<Student> students = context.Students.ToList();
            //return students;

            return context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.SingleOrDefault(s => s.Id == id);
        }

        public int Add(Student student)
        {
            try
            {
                context.Students.Add(student);
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Edit(Student student)
        {
            try
            {
                Student oldStudent = context.Students.SingleOrDefault(s => s.Id == student.Id);
                oldStudent.Name = student.Name;
                oldStudent.Age = student.Age;
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Delete(int id)
        {
            Student student = GetById(id);
            context.Students.Remove(student);
            return context.SaveChanges();
        }
    }


}
