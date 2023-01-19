using Microsoft.EntityFrameworkCore;

namespace LectureDemo.Models
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

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
