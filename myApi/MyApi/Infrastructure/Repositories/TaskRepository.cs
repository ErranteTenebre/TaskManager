using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using MyApi.Models.Entities;


namespace MyApi.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksManagerDbContext _dbContext;
        public TaskRepository(TasksManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TaskEntity Create(TaskEntity model)
        {
            _dbContext.Tasks.Add(model);

            _dbContext.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            TaskEntity task = Get(id);

            if (task == null) return;

            _dbContext.Tasks.Remove(task);

            _dbContext.SaveChanges();
        }

        public TaskEntity Get(int id)
        {
            TaskEntity? model = _dbContext.Tasks.FirstOrDefault(m => m.Id == id);

            return model;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            List<TaskEntity> tasks = _dbContext.Tasks
                .Include(t => t.UserEntity)
                .Include(t => t.StatusEntity)
                .ToList();
            return tasks;
        }

        public void Update(TaskEntity model)
        {
            TaskEntity? modelToUpdate = _dbContext.Tasks.FirstOrDefault(t => t.Id == model.Id);

            if (modelToUpdate == null) return;

            modelToUpdate.Title = model.Title;
            modelToUpdate.Description = model.Description;
            modelToUpdate.EndDate = model.EndDate;

            _dbContext.SaveChanges();
        }
    }
}
