using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Interfaces.Authentication;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO : GuidEntityDTO, ITenantDTO
    {
        [Required] public virtual string Name { get; set; }

        public virtual bool StopOnNew { get; set; }

        #region ITenantDTO Members

        public virtual TenantDTO Tenant { get; set; }

        #endregion
    }
}