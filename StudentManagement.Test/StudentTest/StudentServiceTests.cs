using Moq;
using StudentManagementDAL.Interfaces;
using StudentManagementDATA.Entities;
using StudentManagementDTOs.StudentsDTOs;
using StudentManagemetBAL.Implementations;
using StudentManagemetBAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentManagement.Test.StudentTest
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _repository;
        private readonly IStudentService _service;

        public StudentServiceTests()
        {
            _repository = new Mock<IStudentRepository>();

            _service = new StudentService(_repository.Object);
        }

        [Fact]
        public async Task GetAllStudents_ReturnStudentList()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Pratik",
                    Email = "pratik@gmail.com",
                    Age = 25,
                    Course = ".NET"
                }
            };

            _repository.Setup(x => x.GetAllAsync())
                       .ReturnsAsync(students);

            // Act
            var result = await _service.GetAllStudentsAsync();

            // Assert
            Assert.Single(result);
        }
        [Fact]
        public async Task GetStudentById_ReturnStudent()
        {
            var student = new Student
            {
                Id = 1,
                Name = "Pratik",
                Email = "pratik@gmail.com",
                Age = 25,
                Course = ".NET"
            };

            _repository.Setup(x => x.GetByIdAsync(1))
                       .ReturnsAsync(student);

            var result = await _service.GetStudentByIdAsync(1);

            Assert.NotNull(result);

            Assert.Equal("Pratik", result.Name);
        }

        [Fact]
        public async Task AddStudent_ShouldReturnTrue()
        {
            var dto = new CreateStudentDto
            {
                Name = "Pratik",
                Email = "pratik@gmail.com",
                Age = 25,
                Course = ".NET"
            };

            var result = await _service.AddStudentAsync(dto);

            Assert.True(result);

            _repository.Verify(x => x.AddAsync(It.IsAny<Student>()), Times.Once);

            _repository.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateStudent_ReturnFalse_WhenStudentNotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(10))
                       .ReturnsAsync((Student?)null);

            var dto = new UpdateStudentDto
            {
                Id = 10,
                Name = "ABC",
                Email = "abc@gmail.com",
                Age = 22,
                Course = "SQL"
            };

            var result = await _service.UpdateStudentAsync(dto);

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteStudent_ReturnFalse_WhenStudentNotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(10))
                       .ReturnsAsync((Student?)null);

            var result = await _service.DeleteStudentAsync(10);

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteStudent_ReturnTrue()
        {
            var student = new Student
            {
                Id = 1,
                Name = "Pratik"
            };

            _repository.Setup(x => x.GetByIdAsync(1))
                       .ReturnsAsync(student);

            var result = await _service.DeleteStudentAsync(1);

            Assert.True(result);

            _repository.Verify(x => x.DeleteAsync(student), Times.Once);

            _repository.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
