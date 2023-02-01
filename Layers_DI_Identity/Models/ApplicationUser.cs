using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Layers_DI_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<Product>  products { get; set; }
    }
}
