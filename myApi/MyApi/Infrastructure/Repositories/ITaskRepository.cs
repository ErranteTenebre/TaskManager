using MyApi.Models.Entities;
namespace MyApi.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        TaskEntity Get(int id);
        IEnumerable<TaskEntity> GetAll();
        TaskEntity Create(TaskEntity task);
        void Update(TaskEntity task);
        void Delete(int id);
    }
}
