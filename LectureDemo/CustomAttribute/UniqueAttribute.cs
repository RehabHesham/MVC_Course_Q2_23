using LectureDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace LectureDemo.CustomAttribute
{
    public class UniqueAttribute : ValidationAttribute
    {
        MVC_DemoDbContext context;
        public UniqueAttribute()
        {
            context= new MVC_DemoDbContext();
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? name = value as string;
            if (name == null) return ValidationResult.Success;

            //Student? std = context.Students.FirstOrDefault(s => s.Name == name);
            //if (std == null) return ValidationResult.Success;
            //return new ValidationResult("name is not valid");

            bool invalid = context.Students.Any(s => s.Name == name);
            if(invalid) return new ValidationResult("name is not valid");

            return ValidationResult.Success;
        }
    }
}
