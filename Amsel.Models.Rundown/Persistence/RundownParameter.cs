using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amsel.Models.Rundown.Persistence {
    [ComplexType, Owned]
    public class RundownParameter : INamedEntity {
        protected RundownParameter() { }

        public RundownParameter([NotNull] string name, EParameterType type = EParameterType.TEXTBOX, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DisplayName = name.Replace('.', ' ');
            Type = type;
            Description = description;
        }

        /// <inheritdoc/>
        public RundownParameter([NotNull] string name, string value, EParameterType type = EParameterType.TEXTBOX, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DisplayName = name.Replace('.', ' ');
            Type = type;
            Value = value;
            Description = description;
        }

        public string ArgumentName { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool HasValue => string.IsNullOrEmpty(Value);
        [Key]
        public string Name { get; set; }
        public EParameterType Type { get; set; }
        public string Value { get; set; }
    }
}