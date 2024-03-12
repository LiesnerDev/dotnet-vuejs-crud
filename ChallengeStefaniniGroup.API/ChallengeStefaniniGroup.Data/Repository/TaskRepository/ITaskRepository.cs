namespace ChallengeStefaniniGroup.Data.Repository.TaskRepository
{
    public interface ITaskRepository
    {
        Task<bool> Any(string title);
    }
}
