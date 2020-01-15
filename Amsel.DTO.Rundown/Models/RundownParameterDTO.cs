using System;
using System.ComponentModel.DataAnnotations;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{


    public class RundownParameterDTO : GuidEntityDTO
    {
        private string valueBase;
        public string Description { get; set; }
        [Required]
        public string Type { get; set; } = nameof(EParameterType.STRING);
        // public EParameterType? Type { get; set; } = EParameterType.STRING;

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