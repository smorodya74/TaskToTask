using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.Interfaces.Repositories;
using TaskToTask.DAL;
using TaskToTask.DAL.Repositories;

namespace TaskToTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Регистрируем DbContext
            services.AddDbContext<TaskToTaskDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("TaskToTaskDbContext")));

            // Регистрируем репозитории
            services.AddScoped<IUsersRepository, UsersRepository>();

            // Регистрируем вспомогательные сервисы
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
