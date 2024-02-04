using Microsoft.EntityFrameworkCore;
using MyApi.Dtos;
using SimpleTODOLesson.Models;
using Task = SimpleTODOLesson.Models.Task;


namespace SimpleTODOLesson.Infrastructure.Repositories
{
    public class TaskRepository : ITaskService
    {
        private readonly TasksManagerDbContext _dbContext;
        public TaskRepository(TasksManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(Task model)
        {
            _dbContext.Tasks.Add(model);

            _dbContext.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            Task task = Get(id);

            if (task == null) return;

            _dbContext.Tasks.Remove(task);

            _dbContext.SaveChanges();
        }

        public Task Get(int id)
        {
            Task? model = _dbContext.Tasks.FirstOrDefault(m => m.Id == id);

            return model;
        }

        public IEnumerable<Task> GetAll()
        {
            List<Task> tasks = _dbContext.Tasks
                .Include(t => t.User)
                .Include(t => t.Status)
                .ToList();
            return tasks;
        }

        public void Update(Task model)
        {
            Task? modelToUpdate = _dbContext.Tasks.FirstOrDefault(t => t.Id == model.Id);

            if (modelToUpdate == null) return;

            modelToUpdate.Title = model.Title;
            modelToUpdate.Description = model.Description;
            modelToUpdate.EndDate = model.EndDate;

            _dbContext.SaveChanges();
        }
    }
}
