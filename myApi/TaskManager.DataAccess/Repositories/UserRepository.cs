using TaskManager.Core.Models;
using TaskManager.Core.RepositoriesAbstractions;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Repositories;

//public class UserRepository : IUserRepository
//{
//    private readonly TasksDbContext _context;

//    public UserRepository(TasksDbContext context)
//    {
//        _context = context;
//    }

//    public User Create(string login, string password)
//    {
//        User user = User.Create(login, password).user;

//    }

//    public User GetById(int id)
//    {
//    }

//    public User GetByLogin(string login)
//    {
//    }
//}