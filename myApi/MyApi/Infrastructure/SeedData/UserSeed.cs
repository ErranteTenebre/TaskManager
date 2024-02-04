using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleTODOLesson.Models;
using System.Numerics;
using System.Reflection.Emit;
using Task = SimpleTODOLesson.Models.Task;

namespace MyApi.Infrastructure.EntitiesCongiruration
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasData(
                new User() { Id=1, Login="aidar", Pass="1Exxydnaida"},
                new User() { Id = 2, Login = "jane.smith", Pass = "Pass1234" },
                new User() { Id = 3, Login = "robert.jones", Pass = "SecurePass" },
                new User() { Id = 4, Login = "emily.white", Pass = "StrongPassword" },
                new User() { Id = 5, Login = "alex.martin", Pass = "ComplexPass123" },
                new User() { Id = 6, Login = "olivia.brown", Pass = "Secure123" },
                new User() { Id = 7, Login = "david.miller", Pass = "MyPass567" },
                new User() { Id = 8, Login = "emma.wilson", Pass = "SecretPass" },
                new User() { Id = 9, Login = "william.jackson", Pass = "Password987" },
                new User() { Id = 10, Login = "sophia.davis", Pass = "NewPass123" }
                );
      
        }
    }
}
