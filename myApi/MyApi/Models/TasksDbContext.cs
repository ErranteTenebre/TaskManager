using Microsoft.EntityFrameworkCore;
using MyApi.Infrastructure.EntitiesCongiruration;

namespace SimpleTODOLesson.Models
{
    public class TasksManagerDbContext : DbContext
    {
        public TasksManagerDbContext(DbContextOptions<TasksManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
             .HasOne(t => t.User)
             .WithMany()
             .HasForeignKey(t => t.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.ApplyConfiguration(new UserSeed());
             modelBuilder.ApplyConfiguration(new TaskStatusSeed());
            modelBuilder.ApplyConfiguration(new TaskSeed());

            base.OnModelCreating(modelBuilder);


        }
    }


}
