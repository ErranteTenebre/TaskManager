using TaskManager.Application.Services;
using TaskManager.Core.RepositoriesAbstractions;
using TaskManager.Core.ServicesAbstractions;
using TaskManager.DataAccess.Repositories;

namespace TaskManager.Api.Helpers
{
    public static class DIHelper
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITasksRepository, TasksRepository>();
          //  services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureEntityServices(this IServiceCollection services)
        {
            services.AddTransient<ITasksService, TasksService>();
           // services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddTransient<JwtService>();
            services.AddAuthorization();

            services.AddCors();

            return services;
        }
    }
}