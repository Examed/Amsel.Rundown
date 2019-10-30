using System.Collections.Generic;
using Amsel.DTO.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownCollectionDTO 
    {
        public IList<RundownElementDTO> Elements { get; set; }

        public ERundownFlags RequiredFlags { get; set; }
    }
}