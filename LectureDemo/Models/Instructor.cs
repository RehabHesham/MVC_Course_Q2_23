using System.ComponentModel.DataAnnotations;

namespace LectureDemo.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Display(Name ="Instructor name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        //Navigation Properties

        public List<Course> Courses { get; set; }

    }
}
