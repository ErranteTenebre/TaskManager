using Task= TaskManager.Core.Models.Task;
namespace TaskManager.Core.ServicesAbstractions
{
    public interface ITasksService
    {
        public Task<List<Task>> GetAll();
        public Task<Task> Get(int id);

        public Task<int> Create(Task task);
        public Task<int> Update(int id, string title, string description, DateTime endDate, int userId, int statusId);
        public Task<int> Delete(int id);
    }
}
