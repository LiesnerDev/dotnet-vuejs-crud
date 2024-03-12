using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application.Services.TaskService
{
    public interface ITaskService
    {
        Task<Domain.Entities.Task?> GetTaskById(ObjectId id);
        Task<IEnumerable<Domain.Entities.Task>> GetAllTasks();
        Task<ServiceResponse<Domain.Entities.Task>> AddTask(Domain.Entities.Task newTask);
        Task<ServiceResponse<Domain.Entities.Task>> UpdateTask(Domain.Entities.Task updateTask);
        Task<ServiceResponse<Domain.Entities.Task>> DeleteTask(ObjectId id);
    }
}
