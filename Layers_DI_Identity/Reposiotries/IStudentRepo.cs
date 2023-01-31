using Layers_DI_Identity.Models;

namespace Layers_DI_Identity.Reposiotries
{
    public interface IStudentRepo
    {
        int Add(Student student);
        int Delete(int id);
        int Edit(Student student);
        List<Student> GetAll();
        Student GetById(int id);
    }
}