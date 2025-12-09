using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Interfaces;
using School.Infrastructure.Persistence;
using School.Infrastructure.Repositories;
using School.Infrastructure.Services;

namespace School.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<ISchoolDbContext, SchoolDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();

            return services;
        }
    }
}
