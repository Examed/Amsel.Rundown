using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;
using System;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownParameterDTO : GuidEntity
    {
        private string valueBase;

        public string ArgumentName { get; set; }

        public string Description { get; set; }

        public string DisplayName { get; set; }

        public bool Editable { get; set; }

        public string Name { get; set; }

        public EParameterType Type { get; set; } = EParameterType.TEXTBOX;

        public string Value
        {
            get => valueBase;
            set
            {
                Editable = string.IsNullOrEmpty(value);
                valueBase = value;
            }
        }
    }
}