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
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> Add(AddTaskModel newTask)
        {
            Domain.Entities.Task newObjDomain = _mapper.Map<Domain.Entities.Task>(newTask);
            var result = await _taskService.AddTask(newObjDomain);
            if (!result.Success)
                return BadRequest(result);
            return Ok(new ServiceResponse<TaskModel>() { Message = "Tarefa adicionada com sucesso." });
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> Update(UpdateTaskModel updateTask)
        {
            var result = await _taskService.UpdateTask(_mapper.Map<Domain.Entities.Task>(updateTask));
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> Delete(string id)
        {
            (ObjectId objectId, string message) = ConvertStringToObjectId(id);
            if (!string.IsNullOrEmpty(message))
                return BadRequest(new ServiceResponse<TaskModel>() { Success = false, Message = message });
            var result = await _taskService.DeleteTask(objectId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
