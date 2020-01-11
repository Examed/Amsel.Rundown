using System;
using System.Collections.Generic;
using System.Reflection;
using Amsel.Enums.Rundown.Enums;
using Newtonsoft.Json;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownFunctionDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public virtual EHandlerType HandlerName { get; set; }

        public virtual string Icon { get; set; }

        //public virtual RundownFunctionDTO RevertFunction { get; set; }
        public virtual string Title { get; set; }
        public virtual List<ParameterValueDTO> ParameterValues { get; set; }

        #region Nested type: ValueDTO

      

        #endregion
    }
}