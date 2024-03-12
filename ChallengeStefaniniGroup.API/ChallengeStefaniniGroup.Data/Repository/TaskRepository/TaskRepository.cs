using ChallengeStefaniniGroup.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public class TaskRepository : RepositoryBase<Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public async Task<bool> Any(string title) =>
            await _context.Task.AnyAsync(x => x.Title.ToUpper().Equals(title.ToUpper()));
        
    }
}
