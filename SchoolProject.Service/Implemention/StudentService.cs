using SchoolProject.Data.Entites;
using SchoolProject.Infrastructure.Interface;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implemention
{
    public class StudentService(IUniteOfWork _uniteOfWork) : IStudentService
    {
        public async Task AddStudentAsync(Student studentDto)
        {
            await _uniteOfWork.Repository<Student>().AddAsync(studentDto); // Add 'await' and ensure AddAsync is awaited
            await _uniteOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            // Assuming _uniteOfWork has a method to get the student repository
            var studentRepository = _uniteOfWork.Repository<Student>();
            var student = await studentRepository.GetByIdAsync(id);
            if (student != null)
            {
                await studentRepository.DeleteAsync(student.StudentId);
                await _uniteOfWork.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Student not found.");
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            // Use the unit of work to access the student repository and retrieve all students.
            return await _uniteOfWork.Repository<Student>().GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            // Retrieve the student from the repository using the provided ID
            var student = await _uniteOfWork.Repository<Student>().GetByIdAsync(id);
            return student;
        }

        public async Task UpdateStudentAsync(Student studentDto)
        {
            // Validate the input
            if (studentDto == null)
            {
                throw new ArgumentNullException(nameof(studentDto));
            }

            // Update the student in the repository
            await _uniteOfWork.Repository<Student>().UpdateAsync(studentDto);

            // Save changes asynchronously
            await _uniteOfWork.SaveChangesAsync();
        }
    }
}
