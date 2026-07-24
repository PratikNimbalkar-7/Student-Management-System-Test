using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementDTOs.StudentsDTOs;
using StudentManagemetBAL.Interfaces;

namespace Student_Management_System_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(
            IStudentService studentService,
            ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            _logger.LogInformation("Get All Students API called.");

            var students = await _studentService.GetAllStudentsAsync();

            _logger.LogInformation("Total Students Count : {Count}", students.Count());

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            _logger.LogInformation("Get Student By Id API called. Id : {Id}", id);

            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
            {
                _logger.LogWarning("Student Not Found. Id : {Id}", id);

                return NotFound(new
                {
                    Message = "Student not found."
                });
            }

            _logger.LogInformation("Student Found. Id : {Id}", id);

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentDto dto)
        {
            _logger.LogInformation("Add Student API called.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Model State.");

                return BadRequest(ModelState);
            }

            await _studentService.AddStudentAsync(dto);

            _logger.LogInformation("Student Added Successfully.");

            return Created("", new
            {
                Message = "Student added successfully."
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentDto dto)
        {
            _logger.LogInformation("Update Student API called. Id : {Id}", dto.Id);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid Model State.");

                return BadRequest(ModelState);
            }

            var result = await _studentService.UpdateStudentAsync(dto);

            if (!result)
            {
                _logger.LogWarning("Student Not Found. Id : {Id}", dto.Id);

                return NotFound(new
                {
                    Message = "Student not found."
                });
            }

            _logger.LogInformation("Student Updated Successfully. Id : {Id}", dto.Id);

            return Ok(new
            {
                Message = "Student updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("Delete Student API called. Id : {Id}", id);

            var result = await _studentService.DeleteStudentAsync(id);

            if (!result)
            {
                _logger.LogWarning("Student Not Found. Id : {Id}", id);

                return NotFound(new
                {
                    Message = "Student not found."
                });
            }

            _logger.LogInformation("Student Deleted Successfully. Id : {Id}", id);

            return Ok(new
            {
                Message = "Student deleted successfully."
            });
        }
    }
}