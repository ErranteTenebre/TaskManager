using System.Text;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Helpers;
using TaskManager.DataAccess;

namespace TaskManager.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder);

        var app = builder.Build();

        ConfigureRequestLifetime(app);

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

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


        builder.Services.AddDbContext<TasksDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    }


    private static void ConfigureRequestLifetime(WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(options => options
            .WithOrigins(new[] { "http://localhost:3000" })
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