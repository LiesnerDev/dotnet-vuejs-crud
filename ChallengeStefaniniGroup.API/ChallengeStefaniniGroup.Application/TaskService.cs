using ChallengeStefaniniGroup.Data.Data;
using ChallengeStefaniniGroup.Data.Repository.TaskRepository;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application
{
    public class TaskService : ITaskService
    {
        protected TaskRepository TaskRepository { get; init; }
        public TaskService(DataContext context) => TaskRepository = new TaskRepository(context);
        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks() => await TaskRepository.GetAll();
        public async Task<Domain.Entities.Task?> GetTaskById(ObjectId id) => await TaskRepository.GetById(id);
        public async Task AddTask(Domain.Entities.Task newTask) => await TaskRepository.Add(newTask);
        public async Task DeleteTask(ObjectId id) => await TaskRepository.Delete(id);
        public async Task UpdateTask(Domain.Entities.Task updateTask) => await TaskRepository.Update(updateTask);
    }
}
