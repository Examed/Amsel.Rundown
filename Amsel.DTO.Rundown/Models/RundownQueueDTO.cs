using Amsel.Framework.Base.DTO;
using System.ComponentModel.DataAnnotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO : ShareTenantEntityDTO
    {
        [Required] public string Name { get; set; }

        public bool StopOnNew { get; set; }
    }
}