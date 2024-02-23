using Task = TaskManager.Core.Models.Task;

namespace TaskManager.Core.RepositoriesAbstractions
{
    public interface ITasksRepository
    {
        Task<Task> Get(int id);
        Task<List<Task>> GetAll();
        Task<int> Create(Task task);
        Task<int> Update(int id, string title, string description, DateTime endDate, int userId, int statusId);
        Task<int> Delete(int id);
    }
}
