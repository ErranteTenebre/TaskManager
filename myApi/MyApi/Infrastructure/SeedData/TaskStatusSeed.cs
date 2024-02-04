using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskStatus = SimpleTODOLesson.Models.TaskStatus;

namespace MyApi.Infrastructure.EntitiesCongiruration
{
    public class TaskStatusSeed : IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> modelBuilder)
        {
            modelBuilder.HasData(
            new TaskStatus() { Id = 1, Name ="Выполнена" },
            new TaskStatus() { Id = 2, Name = "В процессе" },
            new TaskStatus() { Id = 3, Name = "Ожидание" }
          );
        }
    }
}
