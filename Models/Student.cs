using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Student
    {
        [Key] 
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public bool IsDeleted { get; set; }  
    }
}
