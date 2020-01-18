using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Interfaces.Authentication;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSequenceDTO : GuidEntityDTO, ITenantDTO
    {
        public virtual string Description { get; set; }
        public virtual List<RundownElementDTO> Elements { get; set; } = new List<RundownElementDTO>();

        [Required] public virtual string Name { get; set; }
        [Required] public virtual ERundownSequence Sequence { get; set; }

        #region ITenantDTO Members

        public virtual TenantDTO Tenant { get; set; }

        #endregion
    }
}