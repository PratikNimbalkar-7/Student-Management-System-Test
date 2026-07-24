using Microsoft.EntityFrameworkCore;
using StudentManagementDAL.Interfaces;
using StudentManagementDATA;
using StudentManagementDATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDAL.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Students
                                 .AnyAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
