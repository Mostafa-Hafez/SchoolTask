using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Application.Interfaces
{
    public interface ISchoolDbContext
    {
        DbSet<Student> Students { get; }
        DbSet<Domain.Entities.Class> Classes { get; }
        DbSet<Course> Courses { get; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
