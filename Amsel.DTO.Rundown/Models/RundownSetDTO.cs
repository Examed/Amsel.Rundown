using System.Collections.Generic;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetDTO
    {
        public virtual string Description { get; set; }
        public List<RundownElementDTO> Elements { get; set; }
        public virtual string Name { get; set; }
        public virtual float Priority { get; set; }
    }
}