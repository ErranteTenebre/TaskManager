using Microsoft.EntityFrameworkCore;
using MyApi.Infrastructure.EntitiesConfigurations;
using MyApi.Infrastructure.SeedData;
using MyApi.Models.Entities;

namespace MyApi.Models;

public class TasksManagerDbContext : DbContext
{
    public TasksManagerDbContext(DbContextOptions<TasksManagerDbContext> options) : base(options)
    {
    }

    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskStatusEntity> TaskStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskConfiguration());

        modelBuilder.ApplyConfiguration(new UserSeed());
        modelBuilder.ApplyConfiguration(new TaskStatusSeed());
        modelBuilder.ApplyConfiguration(new TaskSeed());

        base.OnModelCreating(modelBuilder);
    }
}