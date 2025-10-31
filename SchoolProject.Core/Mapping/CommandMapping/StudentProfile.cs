using SchoolProject.Core.Features.Student.Commands.Models;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    partial class StudentProfile
    {
        public void CreateStudentMapping()
        {
            // CreateMap<Source, Destination>();
            CreateMap<CreateStudentCommand, Student>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
