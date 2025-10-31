using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Student.DTOs.FileDto;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload([FromForm] FileUploadDto file)
        {
            if (file.file == null || file.file.Length == 0)
                return BadRequest("Please upload a valid file.");
            var FolderPath = Path.Combine("Uploads", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
            var SavePath = Path.Combine(Directory.GetCurrentDirectory(), FolderPath);
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            var FullPath = Path.Combine(SavePath, file.file.FileName);
            var dbPath = Path.Combine(FolderPath, file.file.FileName);
            if (Directory.Exists(FullPath))
            {
                Directory.Delete(FullPath);
            }
            using (var stream = new FileStream(FullPath, FileMode.Create))
            {
                await file.file.CopyToAsync(stream);
            }
            return Ok(new { dbPath });
        }
        [HttpPost("upload-multiple"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadMultiple([FromForm] MultipleFileUploadDto files)
        {
            if (files == null || files.files.Count == 0)
                return BadRequest("Please upload valid files.");
            var FolderPath = Path.Combine("Uploads", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
            var SavePath = Path.Combine(Directory.GetCurrentDirectory(), FolderPath);
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            List<string> dbPaths = new List<string>();
            foreach (var file in files.files)
            {
                var FullPath = Path.Combine(SavePath, file.FileName);
                var dbPath = Path.Combine(FolderPath, file.FileName);
                if (Directory.Exists(FullPath))
                {
                    Directory.Delete(FullPath);
                }
                using (var stream = new FileStream(FullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                dbPaths.Add(dbPath);
            }
            return Ok(new { dbPaths });
        }
        [HttpGet("download/{filePath}")]
        public async Task<IActionResult> Download(string filePath)
        {
            var FullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            if (!System.IO.File.Exists(FullPath))
            {
                return NotFound("File not found.");
            }
            var memory = new MemoryStream();
            using (var stream = new FileStream(FullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(FullPath);
            return File(memory, contentType, fileName);
        }
    }
}
