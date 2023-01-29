using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LectureDemo.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        [Required(ErrorMessage ="Name is required")]
        [MinLength(3,ErrorMessage ="Name must be more or equal 3 letters")]
        [Remote("validateName", "CustomValidation",AdditionalFields ="Age",ErrorMessage ="lala is not a valid name")]
        public string Name { get; set; }
        [Display(Name = "Student Age")]
        [Required]
        [Range(20,26)]
        public string Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        //[Phone]
        [RegularExpression("^01[0125][0-9]{8}$")]
        public string phone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string confirmPAssword { get; set; }
    }
}
