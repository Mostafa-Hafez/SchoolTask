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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string schoolconnectionString, string chatconnectionstring)
        {
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer(schoolconnectionString));
            services.AddDbContext<ChatDbContext>(options =>
                options.UseSqlServer(chatconnectionstring));
            services.AddScoped<ISchoolDbContext, SchoolDbContext>();
            services.AddScoped<IChatDbContext, ChatDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IFirebaseNotificationService, FirebaseNotificationService>();
                
            return services;
        }
    }
}
