using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Enrollment
    {
        [Key]  
        public int IdEnrollment { get; set; }
        public DateTime Date { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
