using System;
using JetBrains.Annotations;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownParameterDTO:GuidEntityDTO
    {
        private string valueBase;

        public RundownParameterDTO([NotNull] string name, string value, Type type = null, string description = null) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Value = value;
            Description = description;
            Editable = false;
        }

        public RundownParameterDTO([NotNull] string name, Type type = null, string description = null) {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Description = description;
            Editable = true;
        }

        public RundownParameterDTO() { }
        public string Description { get; set; }
        public Type Type { get; set; }

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