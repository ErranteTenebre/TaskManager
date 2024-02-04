using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleTODOLesson.Models;
using static SimpleTODOLesson.Infrastructure.Repositories.UserRepository;

namespace SimpleTODOLesson.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksManagerDbContext _context;

        public UserRepository(TasksManagerDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            user.Id = _context.SaveChanges();

            return user;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }
    }
    }
