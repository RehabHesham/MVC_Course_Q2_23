namespace LectureDemo.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        //Navigation Properties

        public List<Course> Courses { get; set; }

    }
}
