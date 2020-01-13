using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Utilities.Extentions.Guids;

namespace Amsel.DTO.Rundown.Models
{

    public class GuidEntityDTO
    {
        [Key]
        [Display(Name = nameof(Id))]
        public Guid Id { get; set; } = SequentialGuid.NewMySqlGuid();

    }
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
        [Display(Name = nameof(Priority))] public virtual float Priority { get; set; } = 10;

        [Required]
        public virtual RundownQueueDTO Queue { get; set; }

        public virtual ERundownStatus Status { get; set; }
    }
}