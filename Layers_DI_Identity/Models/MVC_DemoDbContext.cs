using Microsoft.EntityFrameworkCore;

namespace Layers_DI_Identity.Models
{
    public class MVC_DemoDbContext : DbContext
    {
        public MVC_DemoDbContext()
        {

        }
        public MVC_DemoDbContext(DbContextOptions options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Mvc_Demo;Integrated Security=True;TrustServerCertificate = True;");
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
    }
}
