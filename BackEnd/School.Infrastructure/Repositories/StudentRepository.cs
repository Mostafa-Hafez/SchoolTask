using Microsoft.EntityFrameworkCore;
using School.Application.DTOs.StudentDTOs;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Infrastructure.Persistence;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Students
                .Include(s => s.Class)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EnrollmentDTO>> GetErollments(int userid)
        {
            var studentid = await GetStudentId(userid);

            var enrollments = await _context.
                Enrollments.Include(z => z.Student).
                Include(x => x.Course).
                Where(a => a.StudentId == studentid)
                .
                Select(q => new EnrollmentDTO
                {
                    CourseName = q.Course.Name,
                    courseDescription = q.Course.Description
                }).ToListAsync();
            return enrollments;
        }

        public async Task<int> GetStudentId(int userid)
        {
            var studentid = await _context.Students.Where(z => z.UserId == userid).Select(c => c.Id).FirstOrDefaultAsync();
            return studentid;
        }
    }
}
