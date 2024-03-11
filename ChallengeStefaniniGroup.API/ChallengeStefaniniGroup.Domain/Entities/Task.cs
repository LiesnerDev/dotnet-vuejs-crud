using ChallengeStefaniniGroup.Domain.Enum;

namespace ChallengeStefaniniGroup.Domain.Entities
{
    public class Task
    {
        public string Title { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
        public DateTime DateCreated { get; set; }
        public TaskStatusEnum Status { get; set; }
    }
}
