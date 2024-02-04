using SimpleTODOLesson.Models;

namespace SimpleTODOLesson.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByLogin(string login);
        User GetById(int id);
    }
}
