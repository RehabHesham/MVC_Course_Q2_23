using Layers_DI_Identity.ViewModels;

namespace Layers_DI_Identity.Services
{
    public interface IStudentService
    {
        List<studentVM> GetAll();
        studentVM GetById(int id);
    }
}