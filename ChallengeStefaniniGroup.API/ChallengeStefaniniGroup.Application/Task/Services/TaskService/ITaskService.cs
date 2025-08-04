using ChallengeStefaniniGroup.Application.Task.Models.Responses;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Application.Task.Services.TaskService
{
    public interface ITaskService
    {
        Task<TaskResponse?> GetAsync(ObjectId id);
        Task<IEnumerable<TaskResponse>> GetAsync();
    }
}
