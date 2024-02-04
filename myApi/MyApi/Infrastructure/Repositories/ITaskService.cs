using MyApi.Dtos;
using Task = SimpleTODOLesson.Models.Task;
namespace SimpleTODOLesson.Infrastructure.Repositories
{
    public interface ITaskService
    {
        Task Get(int id);
        IEnumerable<Task> GetAll();
        Task Create(Task task);
        void Update(Task task);
        void Delete(int id);
    }
}
