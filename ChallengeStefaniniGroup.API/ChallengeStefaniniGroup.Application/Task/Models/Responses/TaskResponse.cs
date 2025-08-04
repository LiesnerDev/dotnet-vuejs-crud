using ChallengeStefaniniGroup.Domain.Enum;

namespace ChallengeStefaniniGroup.Application.Task.Models.Responses;

public class TaskResponse
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateCreated { get; set; }
    public TaskStatusEnum Status { get; set; }
    public string StatusDisplayName { get => Status.ToString(); }
    public string DateCreatedFormated { get => DateCreated.ToShortDateString(); }
}
