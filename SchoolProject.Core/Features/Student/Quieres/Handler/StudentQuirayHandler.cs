using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Student.DTOs;
using SchoolProject.Core.Features.Student.Quieres.Models;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Student.Quieres.Handler
{
    public class StudentQuirayHandler(IStudentService studentService, IMapper mapper) : ResponseHandler
        , IRequestHandler<GetAllSutdentsQuiery, Response<List<StudentDTO>>>
        , IRequestHandler<GetStudentByIdQuiery, Response<StudentDetailDTO>>
    {
        public async Task<Response<List<StudentDTO>>> Handle(GetAllSutdentsQuiery request, CancellationToken cancellationToken)
        {
            var students = await studentService.GetAllStudentsAsync();
            return Success(mapper.Map<List<StudentDTO>>(students));
        }

        public async Task<Response<StudentDetailDTO>> Handle(GetStudentByIdQuiery request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.Id);
            if(student == null)
            {
                return NotFound<StudentDetailDTO>($"Student with id {request.Id} not found.");
            }
            return Success(mapper.Map<StudentDetailDTO>(student));
        }
    }
}

