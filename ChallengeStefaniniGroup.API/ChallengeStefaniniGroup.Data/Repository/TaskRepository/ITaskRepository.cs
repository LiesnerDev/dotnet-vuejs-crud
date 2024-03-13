using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public interface ITaskRepository
    {
        Task<bool> Any(ObjectId id, string title);
    }
}
