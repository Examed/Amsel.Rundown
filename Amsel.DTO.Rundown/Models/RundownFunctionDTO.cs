using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{

    public class RundownFunctionDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public virtual EHandlerType HandlerName { get; set; }
        public virtual string Icon { get; set; }
        public virtual RundownFunctionDTO RevertFunction { get; set; }
        public virtual string Title { get; set; }
        public virtual List<ValueDTO> Values { get; set; }
        public virtual List<RundownParameterDTO> Parameters { get; set; }
        public class ValueDTO
        {
            public virtual string ParameterId { get; set; }
            public virtual RundownFunctionDTO Function { get; set; }
            public virtual string Value { get; set; }
        }

    }
}