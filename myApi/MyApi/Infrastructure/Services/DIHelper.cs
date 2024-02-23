using MyApi.Helpers;
using MyApi.Infrastructure.Repositories;

namespace MyApi.Infrastructure.Services;

public static class DIHelper
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection ConfigureEntityServices(this IServiceCollection services)
    {
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

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