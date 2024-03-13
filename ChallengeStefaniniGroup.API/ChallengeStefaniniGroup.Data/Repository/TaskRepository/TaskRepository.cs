using ChallengeStefaniniGroup.Data.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public class TaskRepository : RepositoryBase<Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public async Task<bool> Any(ObjectId id, string title) =>
            await _context.Task.AnyAsync(x => !x.Id.Equals(id) && x.Title.ToUpper().Equals(title.ToUpper()));
        
    }
}
