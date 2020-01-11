using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO
    {
        public virtual Guid Id { get; set; }
        public virtual bool CanTriggerRundownSet { get;  set; }
        public virtual int Delay { get; set; }
        public virtual int Duration { get; set; }
        public virtual string Description { get; set; }
        public virtual ERundownSequence Sequence { get; set; }
        public virtual string Title { get; set; }
        public virtual List<ParameterValueDTO> ParameterValues { get; set; }
        public virtual RundownFunctionDTO Functionn { get; set; }
        public virtual RundownSetDTO RundownSet { get; set; }
        public virtual ERundownStatus Status { get; set; }

        #region Nested type: ValueDTO

      
        #endregion
    }
    public class ParameterValueDTO
    {
        public virtual RundownParameterDTO Parameter { get; set; }
        public virtual object Value { get; set; }
    }

}