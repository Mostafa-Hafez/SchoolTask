using Microsoft.EntityFrameworkCore;
using School.Application.Interfaces;
using School.Domain.Entities;
using School.Infrastructure.Persistence;

namespace School.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly SchoolDbContext _context;

        public ClassRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Class cls)
        {
            await _context.Classes.AddAsync(cls);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Class cls)
        {
            _context.Classes.Remove(cls);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Classes
                .Include(c => c.Students)
                .ThenInclude(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ToListAsync();
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            return await _context.Classes
                .Include(c => c.Students)
                .ThenInclude(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Class>> GetPagedAsync(int pageNumber, int pageSize, string classname, string techername)
        {
            return await _context.Classes.Where(z => z.Name.Contains(classname) && z.TeacherName.Contains(techername))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task UpdateAsync(Class cls)
        {
            _context.Classes.Update(cls);
            await _context.SaveChangesAsync();
        }
    }
}
