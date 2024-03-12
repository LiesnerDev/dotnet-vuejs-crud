using ChallengeStefaniniGroup.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ChallengeStefaniniGroup.Core.Models
{
    public class UpdateTaskModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = null!;
        [Required]
        public TaskStatusEnum Status { get; set; }
    }
}
