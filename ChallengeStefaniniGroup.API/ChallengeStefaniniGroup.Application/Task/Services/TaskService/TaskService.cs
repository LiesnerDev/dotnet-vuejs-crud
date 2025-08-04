using ChallengeStefaniniGroup.Application.Task.Models.Responses;
using ChallengeStefaniniGroup.Data.Repository.TaskRepository;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application.Task.Services.TaskService
{
    public class TaskService : ITaskService
    {
        protected ITaskRepository _taskRepository { get; init; }
        public TaskService(ITaskRepository taskRepository) => _taskRepository = taskRepository;
        public async Task<IEnumerable<TaskResponse>> GetAsync() 
        {
            var taskDtos = await _taskRepository.GetAsync();

            var objectResponse = taskDtos.Select(taskDto => new TaskResponse()
            {
                Id = taskDto.Id.ToString(),
                Title = taskDto.Title,
                Description = taskDto.Description,
                DateCreated = taskDto.DateCreated,
                Status = taskDto.Status
            });

            return objectResponse;
        }
        public async Task<TaskResponse?> GetAsync(ObjectId id)
        {
            var taskDto = await _taskRepository.GetAsync(id);
            if (taskDto == null) return null;

            return new TaskResponse()
            {
                Id = taskDto.Id.ToString(),
                Title = taskDto.Title,
                Description = taskDto.Description,
                DateCreated = taskDto.DateCreated,
                Status = taskDto.Status
            };
        }
    }
}
