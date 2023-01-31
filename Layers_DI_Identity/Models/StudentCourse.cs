using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Layers_DI_Identity.Models
{
    public class StudentCourse
    {
        [ForeignKey("std")]
        [Display(Name = "Studnet")]
        public int StdId { get; set; }
        public Student std { get; set; }
        [ForeignKey("crs")]
        [Display(Name = "Course")]

        public int CrsId { get; set; }
        public Course crs { get; set; }
        [Display(Name = "Grade")]

        public int grade { get; set; }
    }
}
