using System.ComponentModel.DataAnnotations.Schema;

namespace LectureDemo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int hours { get; set; }

        // Foreign key
        [ForeignKey("ins_course")]
        public int? InstructorId { get; set; }

        //Navigation property
        public Instructor ins_course { get; set; }
        public List<StudentCourse> studentCrs { get; set; }
    }
}
