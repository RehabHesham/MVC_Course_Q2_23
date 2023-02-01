using System.ComponentModel.DataAnnotations;

namespace Layers_DI_Identity.ViewModels
{
    public class LoginVM
    {
        [Key]
        public string Email { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
