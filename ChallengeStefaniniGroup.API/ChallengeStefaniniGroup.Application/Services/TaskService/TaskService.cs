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
        public async Task<ServiceResponse<Domain.Entities.Task>> AddTask(Domain.Entities.Task newTask)
        {
            if (await AnyTask(new ObjectId(), newTask.Title))
                return new() { Success = false, Message = $"Já existe uma tarefa com o título '{newTask.Title}'" };
            if (!await _taskRepository.Add(newTask))
                return new() { Success = false, Message = "Erro inesperado na inserção da tarefa." };
            return new() { Message = "Tarefa inserida com sucesso." };
        }
        public async Task<ServiceResponse<Domain.Entities.Task>> UpdateTask(Domain.Entities.Task updateTask)
        {
            if (await AnyTask(updateTask.Id, updateTask.Title))
                return new() { Success = false, Message = $"Já existe uma tarefa com o título '{updateTask.Title}'" };

            Domain.Entities.Task? objDomain = await _taskRepository.GetById(updateTask.Id);

            if (objDomain == null)
                return new() { Success = false, Message = "Tarefa não encontrada" };

            objDomain.Update(updateTask.Title, updateTask.Description, updateTask.Status);

            var resultUpdate = await _taskRepository.Update(objDomain);
            if (!resultUpdate.Item1)
                return new() { Success = resultUpdate.Item1, Message = resultUpdate.Item2 };
            return new() { Message = "Tarefa alterada com sucesso." };
        }
        public async Task<ServiceResponse<Domain.Entities.Task>> DeleteTask(ObjectId id)
        {
            var resultDelete = await _taskRepository.Delete(id);
            if (!resultDelete.Item1)
                return new() { Success = false, Message = resultDelete.Item2 };
            return new() { Message = "Tarefa excluída com sucesso" };
        }

        private async Task<bool> AnyTask(ObjectId id, string title) =>
            await _taskRepository.Any(id, title);
    }
}
