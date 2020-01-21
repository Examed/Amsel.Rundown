using System;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.DTO;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownParameterDTO : GuidEntityDTO
    {
        private string valueBase;
        public string Description { get; set; }
        public string Type { get; set; } = nameof(EParameterType.TEXTBOX);

        public string Value
        {
            get => valueBase;
            set
            {
                Editable = string.IsNullOrEmpty(value);
                valueBase = value;
            }
        }

        public string Name { get; set; }
        public bool Editable { get; set; }

    }
}