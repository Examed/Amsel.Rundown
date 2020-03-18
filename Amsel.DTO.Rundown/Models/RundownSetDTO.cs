using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetDTO : TenantEntity
    {
        [Display(Name = nameof(Description))] public string Description { get; set; }

        public string Directory { get; set; } = "";

        public List<RundownElementDTO> Elements { get; set; } = new List<RundownElementDTO>();

        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        public string Name { get; set; }

        // TODO add to Blazor
        [Range(0, 100)]
        [Display(Name = nameof(Priority))]
        public int Priority { get; set; } = 10;

        [Required] public GuidNameEntityDTO Queue { get; set; }

        public List<GuidNameEntityDTO> Sequences { get; set; } = new List<GuidNameEntityDTO>();

        public ERundownStatus Status { get; set; }
    }
}