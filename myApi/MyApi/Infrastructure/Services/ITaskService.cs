using MyApi.Models.Entities;

namespace MyApi.Infrastructure.Services
{
    public interface ITaskService
    {
        public Task<List<TaskEntity>> GetAll();
        public Task<TaskEntity> Get(int id);
    }
}
