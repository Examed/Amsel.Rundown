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
    [ComplexType]
    public class RundownSequenceElement : RundownElement
    {

        public RundownSequence Sequence { get; set; }
        protected RundownSequenceElement() { }

        public RundownSequenceElement(RundownFunction function, RundownSequenceType.EType? sequenceType = null, int delay = 0) : base(function, sequenceType, delay)
        {
        }
    }

    [ComplexType]
    public class RundownSetElement : RundownElement
    {
        public RundownSet RundownSet { get; set; }

        protected RundownSetElement() { }

        public RundownSetElement(RundownFunction function, RundownSequenceType.EType? sequenceType = null, int delay = 0) : base(function, sequenceType, delay)
        {
        }
    }

    public abstract class RundownElement : IGuidEntity, INamedEntity
    {

        protected RundownElement() { }
        public RundownElement(RundownFunction function, RundownSequenceType.EType? sequenceType = null, int delay = 0)
        {
            SequenceType = sequenceType ?? function.SequenceType;
            Function = function;
            Name = function.Name;
            Delay = delay;
        }

        public void AddValue([NotNull] string name, string value)
        {
            List<RundownParameter> parameter = Function.Parameters.Where(x => x.Name == name).ToList();
            foreach (RundownParameter current in parameter)
            {
                ElementValue parameterValue = Values.FirstOrDefault(x => (x?.Parameter != null) && (x.Parameter.Id == current.Id));
                if (parameterValue == null)
                    parameterValue = new ElementValue(current, value);
                else
                    parameterValue.SetValue(value);

                Values.Add(parameterValue);
            }
        }

        [NotNull]
        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> values = Function.Parameters.ToDictionary(item => item.Name, item => item.Value);
            foreach (ElementValue item in Values)
                values[item.Parameter.Name] = item.Value;

            return values;
        }

        public int Delay { get; set; }

        public int Duration { get; set; }

        [Key] public Guid Id { get; set; }

        public string Name { get; set; }

        public RundownSequenceType.EType SequenceType { get; set; }


        public ICollection<ElementValue> Values { get; protected set; } = new List<ElementValue>();

        public RundownFunction Function { get; protected set; }



        [Owned]
        public class ElementValue
        {
            protected ElementValue() { }

            internal ElementValue([NotNull] RundownParameter parameter, string value)
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
}