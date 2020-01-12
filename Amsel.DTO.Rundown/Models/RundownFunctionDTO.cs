using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownFunctionDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public virtual EHandlerType HandlerName { get; set; }
        public virtual string Icon { get; protected set; }
        public virtual RundownFunctionDTO RevertFunction { get; set; }
        public virtual string Title { get; set; }

        public virtual List<RundownParameterDTO> Parameters { get; set; } = new List<RundownParameterDTO>();


        public virtual void AddParameter([NotNull] RundownParameterDTO parameter) { 
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            RundownParameterDTO parameterValue = Parameters?.FirstOrDefault(x => x != null && x.Name.Equals(parameter.Name, StringComparison.OrdinalIgnoreCase));

            if (parameterValue != null)
                parameterValue.Value = parameter.Value;
            else
                Parameters?.Add(parameter);
        }


        public RundownFunctionDTO(string name, EHandlerType handler)
        {
            Title = name;
            HandlerName = handler;
        }

        protected RundownFunctionDTO(){}
    }
}