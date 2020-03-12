using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownTriggerDTO
    {
        public EHandlerType HandlerType { get; set; }

        [NotNull] public Dictionary<string, string> Values { get; set; }

        public RundownTriggerDTO(EHandlerType handlerType, Dictionary<string, string> values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
            HandlerType = handlerType;
        }
    }
}