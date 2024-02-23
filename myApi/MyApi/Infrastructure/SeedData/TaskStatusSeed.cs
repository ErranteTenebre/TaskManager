using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApi.Models.Entities;

namespace MyApi.Infrastructure.SeedData
{
    public class TaskStatusSeed : IEntityTypeConfiguration<TaskStatusEntity>
    {
        public void Configure(EntityTypeBuilder<TaskStatusEntity> modelBuilder)
        {
            modelBuilder.HasData(
            new TaskStatusEntity() { Id = 1, Name ="Выполнена" },
            new TaskStatusEntity() { Id = 2, Name = "В процессе" },
            new TaskStatusEntity() { Id = 3, Name = "Ожидание" }
          );
        }
    }
}
