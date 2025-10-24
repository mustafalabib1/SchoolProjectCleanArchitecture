using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Student.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Student.Quieres.Models
{
    public class GetAllSutdentsQuiery : IRequest<Response<List<StudentDTO>>>
    {
        public GetAllSutdentsQuiery()
        {

        }
    }
}
