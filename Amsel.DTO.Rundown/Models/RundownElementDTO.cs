using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownElementDTO : GuidEntityDTO
    {
        public int Delay { get; set; }

        public int Duration { get; set; }

        [Required] public string Name { get; set; }

        [Required] public RundownSequenceType.EType SequenceType { get; set; }

        public ERundownStatus Status { get; set; }

        [NotNull] public IList<ValueDTO> Values { get; protected set; } = new List<ValueDTO>();

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