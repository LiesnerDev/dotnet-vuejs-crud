using ChallengeStefaniniGroup.Data.Data;
using ChallengeStefaniniGroup.Data.Repository.TaskRepository;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application.Services.TaskService
{
    public class TaskService : ITaskService
    {
        protected TaskRepository TaskRepository { get; init; }
        public TaskService(DataContext context) => TaskRepository = new TaskRepository(context);
        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks() => await TaskRepository.GetAll();
        public async Task<Domain.Entities.Task?> GetTaskById(ObjectId id) => await TaskRepository.GetById(id);
        public async Task<ServiceResponse<Domain.Entities.Task>> AddTask(Domain.Entities.Task newTask)
        {
            if (await TaskRepository.Any(newTask.Title))
                return new() { Success = false, Message = "Já existe uma tarefa com esse título" };
            if (!await TaskRepository.Add(newTask))
                return new() { Success = false, Message = "Erro inesperado na inserção da tarefa." };
            return new() { Message = "Tarefa inserida com sucesso." };
        }
        public async Task DeleteTask(ObjectId id) => await TaskRepository.Delete(id);
        public async Task UpdateTask(Domain.Entities.Task updateTask) => await TaskRepository.Update(updateTask);
    }
}
