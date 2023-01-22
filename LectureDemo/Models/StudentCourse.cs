using System.ComponentModel.DataAnnotations.Schema;

namespace LectureDemo.Models
{
    public class StudentCourse
    {
        [ForeignKey("std")]
        public int StdId { get; set; }
        public Student std { get; set; }
        [ForeignKey("crs")]
        public int CrsId { get; set; }
        public Course crs { get; set; }

        public int grade { get; set; }
    }
}
