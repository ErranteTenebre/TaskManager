using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using MyApi.Models.Entities;

namespace MyApi.Infrastructure.EntitiesConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> modelBuilder)
        {
            modelBuilder.HasKey(t => t.Id); 

            modelBuilder.HasOne(t => t.UserEntity)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(t => t.StatusEntity)
                .WithMany()
                .HasForeignKey(t => t.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
