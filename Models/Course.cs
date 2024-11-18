using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key] 
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
