using ChallengeStefaniniGroup.Core.Extensions;
using ChallengeStefaniniGroup.Domain.Enum;

namespace ChallengeStefaniniGroup.Core.Models
{
    public class TaskModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public TaskStatusEnum Status { get; set; }
        public string StatusDisplayName { get => Status.GetDisplayName(); }
    }
}
