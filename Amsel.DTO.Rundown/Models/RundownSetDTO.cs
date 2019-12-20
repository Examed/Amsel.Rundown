using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetDTO
    {
        [Key] [Display(Name = nameof(Id))]
        public virtual Guid Id { get; set; }

        [Display(Name = nameof(Description))]
        public virtual string Description { get; set; }

        public List<RundownElementDTO> Elements { get; set; }
        public List<RundownWidgetDTO> Widgets { get; set; }

        [Display(Name = nameof(Name))] [Required(ErrorMessage = "Field should not be empty")]
        public virtual string Name { get; set; }

        [Display(Name = nameof(Priority))]
        public virtual float Priority { get; set; }

        public virtual RundownQueueDTO Queue { get; set; }
        public virtual ERundownStatus Status { get; set; }
    }
}