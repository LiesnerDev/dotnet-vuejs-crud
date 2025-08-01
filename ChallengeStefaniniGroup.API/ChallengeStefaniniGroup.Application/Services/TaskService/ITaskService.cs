using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application.Services.TaskService
{
    public interface ITaskService
    {
        Task<Domain.Entities.Task?> GetTaskById(ObjectId id);
        Task<IEnumerable<Domain.Entities.Task>> GetAllTasks();
    }
}
