using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO :GuidEntityDTO
    {
        public virtual bool CanTriggerRundownSet { get; set; }
        public virtual int Delay { get; set; }
        public virtual int Duration { get; set; }
        public virtual string Notes { get; set; }
        public virtual ERundownSequence Sequence { get; set; }
        public virtual string Title { get; set; }
        [NotNull] public virtual IList<ValueDTO> Values { get; protected set; } = new List<ValueDTO>();
        public virtual RundownFunctionDTO Function { get; set; }
        public virtual RundownSetDTO RundownSet { get; set; }
        public virtual ERundownStatus Status { get; set; }

        #region Nested type: ValueDTO

        public class ValueDTO
        {
            public ValueDTO([NotNull] RundownParameterDTO parameter, string value) {
                Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
                Value = value;
            }

            public virtual RundownParameterDTO Parameter { get; set; }
            public virtual string Value { get; set; }
        }

        #endregion
    }
}