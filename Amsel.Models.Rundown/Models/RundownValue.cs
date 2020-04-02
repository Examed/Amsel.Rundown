using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amsel.Models.Rundown.Models
{

    public class RundownValue
    {
        protected RundownValue() { }

        public RundownValue([NotNull] RundownParameter parameter, string value)
        {
            Parameter = parameter;
            Value = value;
        }

        public void SetValue(string value) => Value = value;

        [NotMapped]
        public string ParameterName => Parameter?.Name;
        public RundownParameter Parameter { get; protected set; }
        public string Value { get; set; }
    }
}