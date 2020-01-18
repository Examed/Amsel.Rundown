using System;
using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO : GuidEntityDTO, ITenantDTO
    {

        [Required]
        public virtual string Name { get; set; }

        public virtual bool StopOnNew { get; set; }
        public virtual TenantDTO Tenant { get; set; }
    }
}