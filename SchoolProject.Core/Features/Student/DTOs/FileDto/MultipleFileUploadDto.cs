using Microsoft.AspNetCore.Http;

namespace SchoolProject.Core.Features.Student.DTOs.FileDto
{
    public class MultipleFileUploadDto
    {
        public List<IFormFile> files { get; set; }
        public string FileName { get; set; }
        public string Discription { get; set; }
        public string Author { get; set; }
    }
}
