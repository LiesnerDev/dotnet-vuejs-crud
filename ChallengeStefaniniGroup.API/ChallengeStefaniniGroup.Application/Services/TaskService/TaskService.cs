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
            if (await AnyTask(new ObjectId(), newTask.Title))
                return new() { Success = false, Message = $"Já existe uma tarefa com o título '{newTask}'" };
            if (!await TaskRepository.Add(newTask))
                return new() { Success = false, Message = "Erro inesperado na inserção da tarefa." };
            return new() { Message = "Tarefa inserida com sucesso." };
        }
        public async Task<ServiceResponse<Domain.Entities.Task>> UpdateTask(Domain.Entities.Task updateTask)
        {
            if (await AnyTask(updateTask.Id, updateTask.Title))
                return new() { Success = false, Message = $"Já existe uma tarefa com o título '{updateTask.Title}'" };

            Domain.Entities.Task? objDomain = await TaskRepository.GetById(updateTask.Id);

            if (objDomain == null)
                return new() { Success = false, Message = "Tarefa não encontrada" };

            objDomain.Update(updateTask.Title, updateTask.Description, updateTask.Status);

            var resultUpdate = await TaskRepository.Update(objDomain);
            if (!resultUpdate.Item1)
                return new() { Success = resultUpdate.Item1, Message = resultUpdate.Item2 };
            return new() { Message = "Tarefa alterada com sucesso." };
        }
        public async Task<ServiceResponse<Domain.Entities.Task>> DeleteTask(ObjectId id)
        {
            var resultDelete = await TaskRepository.Delete(id);
            if (!resultDelete.Item1)
                return new() { Success = false, Message = resultDelete.Item2 };
            return new() { Message = "Tarefa excluída com sucesso" };
        }

        private async Task<bool> AnyTask(ObjectId id, string title) =>
            await TaskRepository.Any(id, title);
    }
}
