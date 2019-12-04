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
        public virtual List<ValueDTO> Values { get; set; }
        public virtual RundownSetDTO RundownSet { get; set; }
        public virtual ERundownStatus Status { get; set; }

        public class ValueDTO
        {
            public virtual string ParameterId { get; set; }
            public virtual RundownElementDTO Element { get; set; }
            public virtual string Value { get; set; }
        }
    }
}