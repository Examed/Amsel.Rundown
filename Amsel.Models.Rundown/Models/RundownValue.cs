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

        public RundownValue([NotNull] string parameterName, string value)
        {
            ParameterName = parameterName;
            Value = value;
        }

        public void SetValue(string value) => Value = value;

        public string ParameterName { get; protected set; }

        public string Value { get; set; }
    }
}