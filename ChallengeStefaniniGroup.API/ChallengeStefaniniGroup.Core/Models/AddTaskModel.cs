using ChallengeStefaniniGroup.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ChallengeStefaniniGroup.Core.Models
{
    public class AddTaskModel
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = null!;
        public DateTime DateCreated => DateTime.Now;
        public TaskStatusEnum Status => TaskStatusEnum.Pending;
    }
}
