using AutoMapper;
using ChallengeStefaniniGroup.Application;
using ChallengeStefaniniGroup.Application.Services.TaskService;
using ChallengeStefaniniGroup.Core.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ServiceResponse<List<TaskModel>>> Get()
        {
            IEnumerable<Domain.Entities.Task> objsDomain = await _taskService.GetAllTasks();
            List<TaskModel> objsModel = objsDomain.Select(x => _mapper.Map<TaskModel>(x)).ToList();
            return new() { Data = objsModel };
        }
        [HttpGet("{id}")]
        public async Task<ServiceResponse<TaskModel>> Get(string id)
        {
            (ObjectId objectId, string message) = ConvertStringToObjectId(id);
            if (!string.IsNullOrEmpty(message))
                return new() { Success = false, Message = message };
            Domain.Entities.Task? objectDomain = await _taskService.GetTaskById(objectId);
            if (objectDomain == null)
                return new() { Success = false, Message = "Tarefa não encontrada." };
            return new() { Data = _mapper.Map<TaskModel>(objectDomain) };
        }
    }
}
