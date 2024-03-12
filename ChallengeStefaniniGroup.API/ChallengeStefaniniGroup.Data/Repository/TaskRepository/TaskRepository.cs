using ChallengeStefaniniGroup.Data.Data;
namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public class TaskRepository : RepositoryBase<Domain.Entities.Task>
    {
        public TaskRepository(DataContext context) : base(context) { }
    }
}
