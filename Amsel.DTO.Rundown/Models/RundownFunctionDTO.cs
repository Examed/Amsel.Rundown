using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Base.Interfaces;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownFunctionDTO : ShareTenantEntityDTO
    {
        public string Description { get; set; }

        [Required] public EHandlerType HandlerName { get; set; }
        [Required] public RundownSequenceType.EType SequenceType { get; set; }
        public string Icon { get; set; }

        // TODO Revert
        public RundownFunctionDTO RevertFunction { get; set; }
        public string Name { get; set; }
        public bool IsTrigger { get; set; }

        public List<RundownParameterDTO> Parameters { get; protected set; } = new List<RundownParameterDTO>();

        #region IMultiTenantDTO Members


        #endregion

        public void AddParameter([NotNull] RundownParameterDTO parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            RundownParameterDTO parameterValue = Parameters?.FirstOrDefault(x => x?.Name != null && x.Name.Equals(parameter.Name, StringComparison.OrdinalIgnoreCase));

            if (parameterValue != null)
                parameterValue.Value = parameter.Value;
            else
                Parameters?.Add(parameter);
        }
    }
}