using Amsel.Framework.Base.DTO;
using System.Collections.Generic;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSequenceDTO : ShareTenantEntityDTO
    {
        public string Description { get; set; }

        public List<RundownElementDTO> Elements { get; set; } = new List<RundownElementDTO>();

        public string Name { get; set; }
    }
}