using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownTriggerDTO
    {
        public RundownTriggerDTO(EHandlerType handlerType, Dictionary<string, string> values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
            HandlerType = handlerType;
        }

        public Dictionary<string, string> Values { get; set; }
        public EHandlerType HandlerType { get; set; }
    }
}