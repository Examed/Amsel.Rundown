using System.Collections.Generic;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownTransitionDTO
    {
        public IList<RundownCollectionDTO> Collections { get; set; }

        public RundownFrameworkDTO Framework { get; set; }
    }
}