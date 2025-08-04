using ChallengeStefaniniGroup.Application.Task.Services.TaskService;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _taskService.GetAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _taskService.GetAsync(ObjectId.Parse(id));
            if (response == null)
                return NotFound(id);

            return Ok(response);
        }
    }
}
