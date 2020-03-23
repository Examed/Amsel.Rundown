using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Amsel.Models.Rundown.Models
{
    public class RundownTrigger
    {
        public RundownTrigger(EHandlerType handlerType, Dictionary<string, string> values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
            HandlerType = handlerType;
        }

        public EHandlerType HandlerType { get; set; }

        [NotNull] public Dictionary<string, string> Values { get; set; }
    }
}