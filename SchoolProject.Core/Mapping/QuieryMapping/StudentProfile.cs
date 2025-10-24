using SchoolProject.Core.Features.Student.DTOs;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    public partial class StudentProfile
    {
        public void GetAllStudentsMapping()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));
        }

        public void GetStudentByIdMapping()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Student, StudentDetailDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.Subjects , opt => opt.MapFrom(src=>src.Subjects.Select(sub=>sub.SubjectName)));
        }
    }
}
