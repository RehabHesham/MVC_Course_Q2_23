using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layers_DI_Identity.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int hours { get; set; }

        // Foreign key
        [ForeignKey("ins_course")]
        [Display(Name ="Instructor")]
        public int? InstructorId { get; set; }

        //Navigation property
        public Instructor ins_course { get; set; }
        public List<StudentCourse> studentCrs { get; set; }
    }
}
