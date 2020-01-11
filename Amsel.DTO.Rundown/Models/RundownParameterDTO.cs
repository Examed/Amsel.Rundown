using System;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownParameterDTO
    {
        public virtual string Id { get; set; }
        public virtual bool IsArgument { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual Type Type { get; set; }
    }
}