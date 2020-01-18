using System;
using System.ComponentModel.DataAnnotations;
using Amsel.DTO.Authentication.Models;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

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

        /// <inheritdoc />
    }
}