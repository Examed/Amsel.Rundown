using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownConnectionDTO
    {
        public RundownConnectionDTO(EHandlerType handlerType, string functionName, Dictionary<string, string> values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values));
            HandlerType = handlerType;
            FunctionName = functionName ?? throw new ArgumentNullException(nameof(functionName));
        }

        public Dictionary<string, string> Values { get; set; }
        public EHandlerType HandlerType { get; set; }
        public virtual string FunctionName { get; set; }
    }
}