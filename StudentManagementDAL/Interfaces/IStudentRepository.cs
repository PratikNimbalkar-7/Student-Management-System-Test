using StudentManagementDATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDAL.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(Student student);

        Task<bool> ExistsAsync(int id);

        Task SaveChangesAsync();
    }
}
