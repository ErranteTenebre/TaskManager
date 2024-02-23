using TaskManager.Core.Models;
using Task = TaskManager.Core.Models.Task;

namespace TaskManager.Core.RepositoriesAbstractions
{
    public interface IUserRepository
    {
        Task<User> Create(User userEntity);
        Task<User> GetByLogin(string login);
        Task<User> GetById(int id);
    }
}
