using MyApi.Models;
using MyApi.Models.Entities;

namespace MyApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksManagerDbContext _context;

        public UserRepository(TasksManagerDbContext context)
        {
            _context = context;
        }

        public UserEntity Create(UserEntity userEntity)
        {
            _context.Users.Add(userEntity);
            userEntity.Id = _context.SaveChanges();

            return userEntity;
        }

        public UserEntity GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserEntity GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }
    }
    }
