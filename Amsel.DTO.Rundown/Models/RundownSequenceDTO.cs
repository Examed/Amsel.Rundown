using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Base.Interfaces;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownSequenceDTO : ShareTenantEntityDTO
    {
        public string Description { get; set; }
        public List<RundownElementDTO> Elements { get; set; } = new List<RundownElementDTO>();
        public bool IsBaseSequence { get; set; }
        public string Name { get; set; }
        [Required] public ERundownSequence Sequence { get; set; }
    }
}