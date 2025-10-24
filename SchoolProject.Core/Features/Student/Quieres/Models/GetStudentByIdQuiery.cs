using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Student.DTOs;

namespace SchoolProject.Core.Features.Student.Quieres.Models
{
    public class GetStudentByIdQuiery : IRequest<Response<StudentDetailDTO>>
    {
        public Guid Id { get; set; }
        public GetStudentByIdQuiery(Guid id)
        {
            Id = id;
        }
    }
}