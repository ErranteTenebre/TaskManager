using MyApi.Models.Entities;

namespace MyApi.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        UserEntity Create(UserEntity userEntity);
        UserEntity GetByLogin(string login);
        UserEntity GetById(int id);
    }
}
