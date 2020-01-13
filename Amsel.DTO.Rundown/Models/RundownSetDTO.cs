using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetDTO : GuidEntityDTO
    {

        [Display(Name = nameof(Description))]
        public virtual string Description { get; set; }

        public List<RundownElementDTO> Elements { get; set; }
        public List<RundownWidgetDTO> Widgets { get; set; }


        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        public virtual string Name { get; set; }

        // TODO add to Blazor
        [Range(0, 100)]
        [Display(Name = nameof(Priority))] public virtual int Priority { get; set; } = 10;

        [Required]
        public virtual string QueueName { get; set; }

        public virtual ERundownStatus Status { get; set; }
    }
}