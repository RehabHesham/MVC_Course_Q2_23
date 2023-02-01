using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Layers_DI_Identity.ViewModels;

namespace Layers_DI_Identity.Models
{
    public class MVC_DemoDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public MVC_DemoDbContext()
        {

        }
        public MVC_DemoDbContext(DbContextOptions options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Identity;Integrated Security=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(s => new {s.StdId,s.CrsId});
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Layers_DI_Identity.ViewModels.RegistrationVM> RegistrationVM { get; set; } = default!;
        public DbSet<Layers_DI_Identity.ViewModels.LoginVM> LoginVM { get; set; } = default!;
    }
}
