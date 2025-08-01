using ChallengeStefaniniGroup.Data.Repository.TaskRepository;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application.Services.TaskService
{
    public class TaskService : ITaskService
    {
        protected ITaskRepository _taskRepository { get; init; }
        public TaskService(ITaskRepository taskRepository) => _taskRepository = taskRepository;
        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks() => await _taskRepository.GetAll();
        public async Task<Domain.Entities.Task?> GetTaskById(ObjectId id) => await _taskRepository.GetById(id);
    }
}
