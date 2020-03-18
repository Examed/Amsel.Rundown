using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using JetBrains.Annotations;
using System;

namespace Amsel.Models.Rundown.Models
{
    public class RundownParameter : IGuidEntity, INamedEntity
    {
        public Guid Id { get; set; }
        public  string ArgumentName { get; set; }

        public  string Description { get; set; }

        public  string DisplayName { get; set; }

        public  bool Editable { get; protected set; }

        public  string Name { get; set; }

        public  EParameterType Type { get; set; }
        
        public string Value { get; protected set; }
        public void SetValue(string value)
        {
            Editable = string.IsNullOrEmpty(value);
            Value = value;
        }
        


        #region PUBLIC METHODES
        public  void SetValue(string value)
        {
            Editable = string.IsNullOrEmpty(value);
            Value = value;
        }
        #endregion

        #region  CONSTRUCTORS

        protected RundownParameter() { }

        /// <inheritdoc/>
        public RundownParameter([NotNull] string name, string value, EParameterType type = EParameterType.TEXTBOX, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DisplayName = name.Replace('.', ' ');
            Type = type;
            Value = value;
            Description = description;
            Editable = false;
        }

        public RundownParameter([NotNull] string name, EParameterType type = EParameterType.TEXTBOX, string description = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DisplayName = name.Replace('.', ' ');
            Type = type;
            Description = description;
            Editable = true;
        }
        #endregion
    }
}