using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.RepositoriesAbstractions;
using TaskManager.Core.ServicesAbstractions;
using Task = TaskManager.Core.Models.Task;

namespace TaskManager.Application.Services
{
    public class TasksService : ITasksService
    {
        private ITasksRepository _tasksRepository;
        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<int> Create(Task task)
        {
            return await _tasksRepository.Create(task);
        }

        public async Task<int> Delete(int id)
        {
            return await _tasksRepository.Delete(id);
        }

        public async Task<Task> Get(int id)
        {
            return await _tasksRepository.Get(id);
        }

        public async Task<List<Task>> GetAll()
        {
            return await _tasksRepository.GetAll();
        }

        public async Task<int> Update(int id, string title, string description, DateTime endDate, int userId, int statusId)
        {
            return await _tasksRepository.Update(id, title, description, endDate, userId, statusId);
        }
    }
}
