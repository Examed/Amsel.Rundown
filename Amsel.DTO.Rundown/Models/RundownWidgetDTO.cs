using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSequenceDTO : GuidEntityDTO
    {
        public virtual string Description { get; set; }
        public virtual List<RundownElementDTO> Elements { get; set; } = new List<RundownElementDTO>();

        [Required] public virtual string Name { get; set; }
        [Required] public virtual ERundownSequence Sequence { get; set; }
        public virtual TenantDTO Tenant { get; set; }
    }
}