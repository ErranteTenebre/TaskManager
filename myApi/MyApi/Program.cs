using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;
using MyApi.Helpers;
using MyApi.Infrastructure.Repositories;
using MyApi.Infrastructure.Services;
using MyApi.Models;

namespace MyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder);

            WebApplication app = builder.Build();

            ConfigureRequestLifetime(app);

            app.Run();
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.Always;
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureAuthorization();
            builder.Services.ConfigureEntityServices();


            builder.Services.AddDbContext<TasksManagerDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }


        private static void ConfigureRequestLifetime(WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                .WithOrigins(new[] { "http://localhost:3000"})
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    await context.Response.WriteAsync("Server is started", Encoding.UTF8);
                    return;
                }

                await next(context);
            });

            app.MapDefaultControllerRoute();
        }
    }
}
