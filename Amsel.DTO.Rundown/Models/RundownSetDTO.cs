using System;
using System.Collections.Generic;
using System.ComponentModel;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO
    {
        public Dictionary<string, string> Values { get; set; }
        public ERundownSequence Sequence { get; set; }
        public virtual int Delay { get; set; }
        public virtual string Description { get; set; }
        public virtual string Title { get; set; }
    }



    public class RundownConnectionDTO
    {
        public RundownConnectionDTO(EHandlerType handlerType, string functionName, Dictionary<string, string> values)
        {
            Values = values;
            HandlerType = handlerType;
            FunctionName = functionName;
        }

        public Dictionary<string, string> Values { get; set; }
        public EHandlerType HandlerType { get; set; }
        public virtual string FunctionName { get; set; }
    }

    public class RundownSetDTO
    {
        public virtual string Description { get; set; }
        public List<RundownElementDTO> Elements { get; set; }
        public virtual string Name { get; set; }
        public virtual float Priority { get; set; }
    }
}