using LectureDemo.Models;

namespace LectureDemo.ViewModels
{
    public class StudentCourseVM
    {
        public int StdId { get; set; }
        public int CrsId { get; set; }

        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }
    }
}
