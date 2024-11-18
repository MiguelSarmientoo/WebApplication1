using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Grade
    {
        [Key]  
        public int IdGrade { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public bool IsDeleted { get; set; }  

    }
}
