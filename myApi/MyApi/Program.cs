using System.Text;
using Microsoft.EntityFrameworkCore;
using SimpleTODOLesson.Models;
using SimpleTODOLesson.Infrastructure.Repositories;
using SimpleTODOLesson.Helpers;
using Microsoft.AspNetCore.CookiePolicy;

namespace MyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<ITaskService, TaskRepository>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<JwtService>();

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict; 
                options.HttpOnly = HttpOnlyPolicy.Always; 
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.AddCors();

            builder.Services.AddDbContext<TasksManagerDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                      .WithOrigins(new[] { "http://localhost:3000", "http://localhost:8080", "http://localhost:4200" })
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

            app.Run();
        }
    }
}
