using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Amsel.Models.Rundown.Models
{
      public class RundownElementBase : LogicEntity
    {
        public int Delay { get; set; }

        public int Duration { get; set; }

        public RundownSet RundownSet { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public RundownSequenceType.EType SequenceType { get; set; }

        public ICollection<RundownElementValue> Values { get; protected set; } = new List<RundownElementValue>();

        [ComplexType, Owned]
        public class RundownElementValue 
        {
            protected RundownElementValue() { }

            internal RundownElementValue([NotNull] RundownParameter parameter, string value)
            {
                Parameter = parameter;
                Value = value;
            }

            public void SetValue(string value) => Value = value;

            [Key]
            public RundownParameter Parameter { get; protected set; }

            public string Value { get; set; }
        }
    }


    /// <inheritdoc cref="GuidEntity"/>
    /// <summary>
    /// An Implementation of a RundownFunction
    /// </summary>
    public class RundownElement : RundownElementBase
    {
        protected RundownElement() { }


        public RundownElement(RundownFunction function, RundownSequenceType.EType? sequence = null, int delay = 0)
        {
            SequenceType = sequence ?? function.SequenceType;
            Function = function;
            Name = function.Name;
            Delay = delay;
        }

        public void AddValue([NotNull] string name, string value)
        {
            List<RundownParameter> parameter = Function.Parameters.Where(x => x.Name == name).ToList();
            foreach (RundownParameter current in parameter)
            {
                RundownElementValue parameterValue = Values.FirstOrDefault(x => (x?.Parameter != null) && (x.Parameter.Id == current.Id));
                if (parameterValue == null)
                    parameterValue = new RundownElementValue(current, value);
                else
                    parameterValue.SetValue(value);

                Values.Add(parameterValue);
            }
        }

        [NotNull]
        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> values = Function.Parameters.ToDictionary(item => item.Name, item => item.Value);
            foreach (RundownElementValue item in Values)
                values[item.Parameter.Name] = item.Value;

            return values;
        }

        public RundownFunction Function { get; protected set; }

        public RundownSequence Sequence { get; set; }
    }
}