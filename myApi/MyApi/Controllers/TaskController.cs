using Microsoft.AspNetCore.Mvc;
using MyApi.Dtos;
using MyApi.Infrastructure.Repositories;
using MyApi.Models.Entities;

namespace MyApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private ITaskRepository _taskService;
        public TaskController(ITaskRepository taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]TaskCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest();

            TaskEntity task = new TaskEntity()
            {
                Title = model.Title,
                Description = model.Description,
                EndDate = model.endDate,
                UserId = model.UserId,
                StatusId = 3
            };

            return Created("success", _taskService.Create(task));
        }
        [HttpPatch]
        public void Update(TaskEntity model)
        {
            _taskService.Update(model);
        }
        [HttpGet("{id}")]   
        public TaskEntity Get(int id)
        {
            return _taskService.Get(id);
        }

        [HttpGet]
        public IEnumerable<TaskEntity> GetAll()
        {
            return _taskService.GetAll();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {   
            _taskService.Delete(id);
        }
    }
}
