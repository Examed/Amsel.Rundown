using System.Collections.Generic;
using Amsel.DTO.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSetDTO 
    {
        public ERundownFlags AllocatedFlags { get; set; }

        public IList<RundownCollectionDTO> Collections { get; set; }

        public RundownFrameworkDTO Framework { get; set; }

        public RundownTransitionDTO Transition { get; set; }

        public IList<RundownSetDTO> Variations { get; set; }
    }
}