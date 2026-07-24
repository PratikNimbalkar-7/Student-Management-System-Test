using StudentManagementDTOs.StudentsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagemetBAL.Interfaces
{
    public interface IStudentService 
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();

        Task<StudentDto?> GetStudentByIdAsync(int id);

        Task<bool> AddStudentAsync(CreateStudentDto dto);

        Task<bool> UpdateStudentAsync(UpdateStudentDto dto);

        Task<bool> DeleteStudentAsync(int id);
    }
}
