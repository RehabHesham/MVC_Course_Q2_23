using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Layers_DI_Identity.ViewModels
{
    public class RegistrationVM
    {
        [Key]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
