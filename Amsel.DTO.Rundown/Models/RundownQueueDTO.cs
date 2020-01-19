using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Base.Interfaces;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownQueueDTO : ShareTenantEntityDTO
    {
        [Required] public  string Name { get; set; }

        public  bool StopOnNew { get; set; }

    }
}