namespace Layers_DI_Identity.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        //Navigation prop

        public List<StudentCourse> StudentCourses { get; set; }
    }
}
