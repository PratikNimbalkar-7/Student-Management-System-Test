using StudentManagementDAL.Interfaces;
using StudentManagementDATA.Entities;
using StudentManagementDTOs.StudentsDTOs;
using StudentManagemetBAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemetBAL.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repository.GetAllAsync();

            return students.Select(x => new StudentDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Course = x.Course,
                CreatedDate = x.CreatedDate
            });
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };
        }

        public async Task<bool> AddStudentAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.Now
            };

            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateStudentAsync(UpdateStudentDto dto)
        {
            var student = await _repository.GetByIdAsync(dto.Id);

            if (student == null)
                return false;

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _repository.UpdateAsync(student);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return false;

            await _repository.DeleteAsync(student);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
