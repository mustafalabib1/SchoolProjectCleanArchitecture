namespace SchoolProject.Core.Features.Student.DTOs
{
    public class StudentDetailDTO : StudentDTO
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Subjects { get; set; }
    }
}
