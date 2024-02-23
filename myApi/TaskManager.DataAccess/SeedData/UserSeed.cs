using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.SeedData
{
    public class UserSeed : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> modelBuilder)
        {
            modelBuilder.HasData(
                new UserEntity() { Id=1, Login="aidar", Pass="1Exxydnaida"},
                new UserEntity() { Id = 2, Login = "jane.smith", Pass = "Pass1234" },
                new UserEntity() { Id = 3, Login = "robert.jones", Pass = "SecurePass" },
                new UserEntity() { Id = 4, Login = "emily.white", Pass = "StrongPassword" },
                new UserEntity() { Id = 5, Login = "alex.martin", Pass = "ComplexPass123" },
                new UserEntity() { Id = 6, Login = "olivia.brown", Pass = "Secure123" },
                new UserEntity() { Id = 7, Login = "david.miller", Pass = "MyPass567" },
                new UserEntity() { Id = 8, Login = "emma.wilson", Pass = "SecretPass" },
                new UserEntity() { Id = 9, Login = "william.jackson", Pass = "Password987" },
                new UserEntity() { Id = 10, Login = "sophia.davis", Pass = "NewPass123" }
                );
      
        }
    }
}
