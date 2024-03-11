using System.ComponentModel.DataAnnotations;

namespace ChallengeStefaniniGroup.Domain.Enum
{
    public enum TaskStatusEnum
    {
        [Display(Name = "Pendente")]
        Pending = 0,
        [Display(Name = "Em Andamento")]
        Progress = 1,
        [Display(Name = "Concluída")]
        Completed = 2
    }
}
