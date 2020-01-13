using System;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{


    public class RundownParameterDTO:GuidEntityDTO
    {
        private string valueBase;
        public string Description { get; set; }
        public EParameterType Type { get; set; }

        public string Value {
            get => valueBase;
            set {
                Editable = string.IsNullOrEmpty(value);
                valueBase = value;
            }
        }

        public string Name { get; set; }
        public bool Editable { get; set; }
    }
}