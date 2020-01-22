using System;
using System.Collections.Generic;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO : GuidEntityDTO
    {
        public int Delay { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        [NotNull] public IList<ValueDTO> Values { get; protected set; } = new List<ValueDTO>();

        public ERundownStatus Status { get; set; }

        #region Nested type: ValueDTO

        public class ValueDTO
        {
            public ValueDTO([NotNull] RundownParameterDTO parameter, string value)
            {
                Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
                Value = value;
            }

            public RundownParameterDTO Parameter { get; set; }
            public string Value { get; set; }
        }

        #endregion
    }
}