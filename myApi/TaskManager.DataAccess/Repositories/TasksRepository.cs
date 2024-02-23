using Microsoft.EntityFrameworkCore;
using TaskManager.Core.RepositoriesAbstractions;
using TaskManager.DataAccess.Entities;
using Task = TaskManager.Core.Models.Task;

namespace TaskManager.DataAccess.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TasksDbContext _dbContext;
        public TasksRepository(TasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Task task)
        {
            TaskEntity taskEntity = new TaskEntity()
            {
                Title = task.Title,
                Description = task.Description,
                EndDate = task.EndDate,
                StatusId = task.StatusId,
                UserId = task.UserId,
            };

            await _dbContext.AddAsync(taskEntity);
            await _dbContext.SaveChangesAsync();

            return taskEntity.Id;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Get(int id)
        {
            TaskEntity taskEntity = await _dbContext.Tasks.FirstOrDefaultAsync(m => m.Id == id);

            Task task = Task.Create(taskEntity.Title, taskEntity.Description, taskEntity.EndDate, taskEntity.UserId,
                taskEntity.StatusId).task;

            return task;
        }

        public async Task<List<Task>> GetAll()
        {
            List<TaskEntity> taskEntities = await _dbContext.Tasks
                .AsNoTracking()
                .ToListAsync();

            List<Task> tasks = taskEntities.Select(e=> Task.Create(e.Title,e.Description,e.EndDate,e.UserId,e.StatusId).task).ToList();
            return tasks;
        }

        public async Task<int> Update(int id, string title, string description, DateTime endDate, int userId, int statusId)
        {
            await _dbContext.Tasks.Where(e => e.Id == id)
                .ExecuteUpdateAsync(e => e
                    .SetProperty(e => e.Title, e => title)
                    .SetProperty(e => e.Description, e => description)
                    .SetProperty(e => e.EndDate, e => endDate)
                    .SetProperty(e => e.UserId, e => userId)
                    .SetProperty(e => e.StatusId, e => statusId));

            return id;
        }
    }
}
