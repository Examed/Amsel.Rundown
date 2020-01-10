using System;
using System.ComponentModel.DataAnnotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO
    {
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string Name { get; set; }
      
        public virtual bool StopOnNew { get; set; }
    }
}