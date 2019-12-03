using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO
    {
        public virtual Guid Id { get; set; }
        public RundownFunctionDTO Function { get; set; }
        public virtual bool CanTriggerRundownSet { get; protected set; }
        public virtual string Type { get; set; }
        public virtual int Delay { get; set; }
        public virtual int Duration { get; protected set; }
        public virtual string Description { get; set; }
        public virtual ERundownSequence Sequence { get; set; }
        public virtual string Title { get; set; }
        public virtual Dictionary<string, string> Values { get; set; }
        public virtual RundownSetDTO RundownSet { get; set; }
        public virtual ERundownStatus Status { get; set; }
    }

    public class RundownParameterDTO
    {
        public virtual string Id { get; set; }
        public virtual bool IsArgument { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual EParameterType Type { get; set; }
    }

    public class RundownFunctionDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public virtual EHandlerType HandlerName { get; set; }
        public virtual string Icon { get; set; }
        public virtual RundownFunctionDTO RevertFunction { get; set; }
        public virtual string Title { get; set; }
        public virtual Dictionary<string, string> Values { get; set; }
        public virtual List<RundownParameterDTO> Parameters { get; set; }
    }
}