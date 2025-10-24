using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Student : BaseEntity
    {
        public Guid StudentId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set;  }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Department Department { get; set; }
        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
