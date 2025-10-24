using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entites
{
    public class Subject : BaseEntity
    {
        public Guid SubjectId { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }

}
