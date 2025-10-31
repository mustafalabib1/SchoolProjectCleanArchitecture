using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Student.Commands.Models;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Student.Commands.Handler
{
    public class StudentCommandHandler(IStudentService studentService, IMapper mapper) : ResponseHandler,
        IRequestHandler<CreateStudentCommand, Response<string>>
    {

        public async Task<Response<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = mapper.Map<SchoolProject.Data.Entites.Student>(request);
            await studentService.AddStudentAsync(studentEntity);
            return Success("Student created successfully.");
        }
    }
}