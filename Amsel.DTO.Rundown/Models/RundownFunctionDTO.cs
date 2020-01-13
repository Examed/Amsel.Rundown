using System;
using System.Collections.Generic;
using System.Linq;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownFunctionDTO:GuidEntityDTO
    {
        public virtual string Description { get; set; }
        public virtual EHandlerType HandlerName { get; set; }
        public virtual string Icon { get; set; }
        public virtual RundownFunctionDTO RevertFunction { get; set; }
        public virtual string Title { get; set; }

        public virtual List<RundownParameterDTO> Parameters { get; protected set; } = new List<RundownParameterDTO>();


        public virtual void AddParameter([NotNull] RundownParameterDTO parameter) {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            RundownParameterDTO parameterValue = Parameters?.FirstOrDefault(x => x?.Name != null && x.Name.Equals(parameter.Name, StringComparison.OrdinalIgnoreCase));

            if (parameterValue != null)
                parameterValue.Value = parameter.Value;
            else
                Parameters?.Add(parameter);
        }

    }
}