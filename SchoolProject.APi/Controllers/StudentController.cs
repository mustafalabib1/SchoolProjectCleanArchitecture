using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Student.Quieres.Models;
using SchoolProject.Core.Features.Student.Quieres.Models;
using System.Threading.Tasks;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        // GET /api/Student/123e4567-e89b-12d3-a456-426614174000
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var response = await mediator.Send(new GetStudentByIdQuiery(id));
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var response = await mediator.Send(new GetAllSutdentsQuiery());
            return StatusCode((int)response.StatusCode, response);
        }
    }
}