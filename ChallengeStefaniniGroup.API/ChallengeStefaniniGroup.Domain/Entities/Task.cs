using ChallengeStefaniniGroup.Domain.Enum;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Domain.Entities
{
    public class Task
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
        public DateTime DateCreated { get; set; }
        public TaskStatusEnum Status { get; set; }
    }
}
