using ChallengeStefaniniGroup.Domain.Enum;
using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Domain.DTOs;

public class TaskDTO
{
    public TaskDTO() { }
    public TaskDTO(string title, string descricao)
    {
        Title = title;
        Description = descricao;
        DateCreated = DateTime.Now;
        Status = TaskStatusEnum.Pending;
    }
    public ObjectId Id { get; set; }
    public string Title { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public DateTime DateCreated { get; set; }
    public TaskStatusEnum Status { get; set; }
}
