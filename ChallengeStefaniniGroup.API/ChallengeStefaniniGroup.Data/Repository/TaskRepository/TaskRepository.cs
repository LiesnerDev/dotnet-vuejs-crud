using ChallengeStefaniniGroup.Data.Data;
using ChallengeStefaniniGroup.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public class TaskRepository : RepositoryBase<Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context) { }

        public async Task<bool> Any(ObjectId id, string title) =>
            await _context.Task.AnyAsync(x => !x.Id.Equals(id) && x.Title.ToUpper().Equals(title.ToUpper()));
        
        public async Task<List<TaskDTO>> GetAsync()
        {
            var objectsDomain = await _context.Task.ToListAsync();

            return objectsDomain.Select(x => new TaskDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DateCreated = x.DateCreated,
                Status = x.Status
            }).ToList();
        }

        public async Task<TaskDTO> GetAsync(ObjectId id)
        {
            var objectDomain = await GetById(id);

            if (objectDomain == null)
                throw new Exception("Task not found");

            return new TaskDTO() 
            { 
                Id = objectDomain.Id,
                Description = objectDomain.Description,
                DateCreated = objectDomain.DateCreated,
                Status = objectDomain.Status,
                Title = objectDomain.Title
            };
        }
    }
}
