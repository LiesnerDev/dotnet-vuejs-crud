using ChallengeStefaniniGroup.Domain.DTOs;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public interface ITaskRepository : IRepositoryBase<Domain.Entities.Task>
    {
        Task<bool> Any(ObjectId id, string title);

        Task<List<TaskDTO>> GetAsync();

        Task<TaskDTO> GetAsync(ObjectId id);
    }
}
