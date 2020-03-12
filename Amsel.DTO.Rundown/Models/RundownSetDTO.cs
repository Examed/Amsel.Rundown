using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Utilities.Extensions.Guids;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetInfoDTO : TenantEntityDTO
    {
        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        public string Name { get; set; }

        public string Directory { get; set; }

        public ERundownStatus Status { get; set; }

        [Display(Name = nameof(Description))] public string Description { get; set; }
        [Required] public (Guid Id, string Name) Queue { get; set; }
    }
    public class RundownSetDTO : RundownSetInfoDTO
    {
        // TODO add to Blazor
        [Range(0, 100)]
        [Display(Name = nameof(Priority))]
        public int Priority { get; set; } = 10;
        public List<(Guid Id, string Name)> Sequences { get; set; }= new List<(Guid Id, string Name)>();
        public List<RundownElementDTO> Elements { get; set; } = new List<RundownElementDTO>();

    }
}