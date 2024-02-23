using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Dots;
using TaskManager.Core.ServicesAbstractions;
using Task = TaskManager.Core.Models.Task;

namespace TaskManager.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private ITasksService _tasksService;
        public TaskController(ITasksService taskService)
        {
            _tasksService = taskService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]TaskRequestDto request)
        {
            (Task task, string error) =
                Task.Create(request.Title, request.Description, request.EndDate, request.UserId, request.StatusId);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            int taskId = await _tasksService.Create(task);

            return Ok(taskId);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> Update(int id, [FromBody] TaskRequestDto request)
        {
            int taskId = await _tasksService.Update(id, request.Title, request.Description, request.EndDate, request.UserId,
                request.StatusId);

            return Ok(taskId);
        }
        [HttpGet("{id}")]   
        public async Task<ActionResult<TaskResponseDto>> Get(int id)
        {
            Task task = await _tasksService.Get(id);

            TaskResponseDto result = new TaskResponseDto(task.Title, task.Description,task.EndDate,
                task.UserId, task.StatusId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskResponseDto>>> GetAll()
        {
            List<Task> tasks = await _tasksService.GetAll();

            List<TaskResponseDto> result = tasks.Select(t =>
                new TaskResponseDto(t.Title, t.Description, t.EndDate, t.UserId, t.StatusId)).ToList();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tasksService.Delete(id);
        }
    }
}
