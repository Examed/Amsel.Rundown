using System;
using System.ComponentModel.DataAnnotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO : GuidEntityDTO
    {

        [Required]
        public virtual string Name { get; set; }

        public virtual bool StopOnNew { get; set; }
    }
}