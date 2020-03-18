using System.ComponentModel.DataAnnotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO : ShareTenantEntity
    {
        [Required] public string Name { get; set; }

        public bool StopOnNew { get; set; }
    }
}