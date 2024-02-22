using Microsoft.AspNetCore.Mvc;
using System;
using Task =  SimpleTODOLesson.Models.Task;
using SimpleTODOLesson.Infrastructure.Repositories;
using MyApi.Dtos;

namespace SimpleTODOLesson.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]TaskCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest();

            Task task = new Task()
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
        public void Update(Task model)
        {
            _taskService.Update(model);
        }
        [HttpGet("{id}")]   
        public Task Get(int id)
        {
            return _taskService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Task> GetAll()
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
