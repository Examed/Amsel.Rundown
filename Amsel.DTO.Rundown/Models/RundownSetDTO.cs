using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Utilities.Extensions.Guids;

namespace Amsel.DTO.Rundown.Models
{


    public class RundownSetDTO : GuidEntityDTO
    {
        [Display(Name = nameof(Description))] public  string Description { get; set; }

        public List<RundownSequenceDTO> Sequences { get; set; }


        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        public  string Name { get; set; }

        // TODO add to Blazor
        [Range(0, 100)]
        [Display(Name = nameof(Priority))]
        public  int Priority { get; set; } = 10;

        [Required] public  string QueueName { get; set; }

        public  ERundownStatus Status { get; set; }
    }
}