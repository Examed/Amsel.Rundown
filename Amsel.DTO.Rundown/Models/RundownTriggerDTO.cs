using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownTriggerDTO
    {
        public RundownTriggerDTO(EHandlerType handlerType, Dictionary<string, string> values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
            HandlerType = handlerType;
        }

        [NotNull] public Dictionary<string, string> Values { get; set; }
        public EHandlerType HandlerType { get; set; }
    }
}