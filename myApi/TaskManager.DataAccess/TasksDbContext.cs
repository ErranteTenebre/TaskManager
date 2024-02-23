using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;
using TaskManager.DataAccess.EntitiesConfigurations;
using TaskManager.DataAccess.SeedData;

namespace TaskManager.DataAccess;

public class TasksDbContext : DbContext
{
    public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
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