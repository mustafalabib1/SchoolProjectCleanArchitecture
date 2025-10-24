using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entites
{
    public class Department : BaseEntity
    {
        public Guid DepartmentId { get; set; }
        [StringLength(500)]
        public string DepartmentName { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
