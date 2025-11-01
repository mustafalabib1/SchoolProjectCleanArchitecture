using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Student.Commands.Models
{
    public class CreateStudentCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
