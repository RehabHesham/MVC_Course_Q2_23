using Layers_DI_Identity.Reposiotries;

namespace Layers_DI_Identity.Services
{
    public class DI
    {
        private IStudentRepo studentRepo;
        //constructor
        //public DI(IStudentRepo studentRepo) {
        //    studentRepo = studentRepo;
        //}

        // Method
        public void SetDependency(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        //propery
        public IStudentRepo studentRepo1 { set { 
                studentRepo = value;
            } }
    }

    public class factory
    {
         public static IStudentRepo getObject()
        {
            return new StudentRepo(new Models.MVC_DemoDbContext());
        }
    }

    public class myMain
    {
        public void myMainFunc()
        {

            //DI constructor
            //DI dI = new DI(factory.getObject());

            // DI Method
            //DI dI = new DI();
            //dI.SetDependency(factory.getObject());

            // DI prop
            DI dI = new DI();
            dI.studentRepo1 = factory.getObject();
        }
    }
}
