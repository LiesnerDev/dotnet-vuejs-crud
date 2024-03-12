using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application
{
    public interface ITaskService
    {
        Task<Domain.Entities.Task?> GetTaskById(ObjectId id);
        Task<IEnumerable<Domain.Entities.Task>> GetAllTasks();
        Task AddTask(Domain.Entities.Task newTask);
        Task UpdateTask(Domain.Entities.Task updateTask);
        Task DeleteTask(ObjectId id);
    }
}
