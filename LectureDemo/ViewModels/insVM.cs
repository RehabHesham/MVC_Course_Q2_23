using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LectureDemo.ViewModels
{
    public class insVM
    {
        public int Id { get; set; }
        [Display(Name = "Instructor name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        [Display(Name ="Course")]
        public int crsId { get; set; }
        public SelectList courses { get; set; }
    }
}
