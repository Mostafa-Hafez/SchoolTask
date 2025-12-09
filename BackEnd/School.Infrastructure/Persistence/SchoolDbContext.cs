using Microsoft.EntityFrameworkCore;
using School.Application.Interfaces;
using School.Domain.Entities;

namespace School.Infrastructure.Persistence
{
    public class SchoolDbContext : DbContext ,ISchoolDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Teacher" },
                new Role { Id = 3, Name = "Student" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "ahmed12", Password = "12345", RoleId = 3 },
                new User { Id = 2, Username = "khaled12", Password = "12345", RoleId = 3 },
                new User { Id = 3, Username = "eslam12", Password = "12345", RoleId = 3 },
                new User { Id = 4, Username = "mariam12", Password = "12345", RoleId = 3 },
                new User { Id = 5, Username = "doaa12", Password = "12345", RoleId = 3 },
                new User { Id = 6, Username = "zeyad12", Password = "12345", RoleId = 3 }
            );
            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, Name = "Class A", TeacherName = "Mr. Ali" },
                new Class { Id = 2, Name = "Class B", TeacherName = "Ms. Sara" },
                new Class { Id = 3, Name = "Class C", TeacherName = "Mr. Hossam" }
            );

            modelBuilder.Entity<Student>().HasData(
               new Student { Id = 1, Name = "Ahmed", Email = "ahmed12@school.com", ClassId = 1, UserId = 1 },
               new Student { Id = 2, Name = "Khaled", Email = "khaled12@school.com", ClassId = 3, UserId = 2 },
               new Student { Id = 3, Name = "Eslam", Email = "eslam12@school.com", ClassId = 2, UserId = 3 },
               new Student { Id = 4, Name = "Mariam", Email = "mariam12@school.com", ClassId = 1, UserId = 4 },
               new Student { Id = 5, Name = "Doaa", Email = "doaa12@school.com", ClassId = 3, UserId = 5 },
               new Student { Id = 6, Name = "Zeyad", Email = "zyad12@school.com", ClassId = 2, UserId = 6 }
           );


            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Math", Description = "Mathematics" },
                new Course { Id = 2, Name = "Arabic", Description = "Arabic Language" },
                new Course { Id = 3, Name = "History", Description = "History" }
            );



            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1 },
                new Enrollment { Id = 2, StudentId = 1, CourseId = 2 },
                new Enrollment { Id = 3, StudentId = 1, CourseId = 3 },
                new Enrollment { Id = 4, StudentId = 2, CourseId = 2 },
                new Enrollment { Id = 5, StudentId = 2, CourseId = 1 },
                new Enrollment { Id = 6, StudentId = 3, CourseId = 3 },
                new Enrollment { Id = 7, StudentId = 4, CourseId = 1 },
                new Enrollment { Id = 8, StudentId = 5, CourseId = 3 },
                new Enrollment { Id = 9, StudentId = 6, CourseId = 3 },
                new Enrollment { Id = 10, StudentId = 6, CourseId = 2 }
            );
        }
    }
}
