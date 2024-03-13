using ChallengeStefaniniGroup.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace ChallengeStefaniniGroup.Core.Models
{
    public class AddTaskModel
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
    }
}
