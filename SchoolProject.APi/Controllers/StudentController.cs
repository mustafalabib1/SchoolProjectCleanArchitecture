using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Student.Commands.Models;
using SchoolProject.Core.Features.Student.Quieres.Models;
using SchoolProject.Core.Features.Student.Quieres.Models;
using SchoolProject.Data.APPMetaData;
using System.Threading.Tasks;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        [HttpGet(Router.StudentRouting.GetById)]
        // GET /api/v1/Student/123e4567-e89b-12d3-a456-426614174000
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var response = await mediator.Send(new GetStudentByIdQuiery(id));
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await mediator.Send(new GetAllSutdentsQuiery());
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var response = await mediator.Send(command);
            return StatusCode((int)response.StatusCode, response);
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid file.");

            var filePath = Path.Combine("Uploads", file.FileName);
            Directory.CreateDirectory("Uploads");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath });
        }
    }
}