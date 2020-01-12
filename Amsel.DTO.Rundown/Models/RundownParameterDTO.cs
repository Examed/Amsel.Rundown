using System;
using Amsel.Enums.Rundown.Enums;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownParameterDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }


        private string valueBase;
        
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

        public RundownParameterDTO([NotNull] string name, string value, Type type = null, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Value = value;
            Description = description;
            Editable = false;
        }

        public RundownParameterDTO([NotNull] string name, Type type = null, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Description = description;
            Editable = true;
        }

        protected RundownParameterDTO(){}
        

    }
}