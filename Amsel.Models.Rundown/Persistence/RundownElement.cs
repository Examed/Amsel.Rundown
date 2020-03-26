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

    public class RundownElement : IGuidEntity, INamedEntity
    {
        public RundownElement() { }
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
                ElementValue parameterValue = Values.FirstOrDefault(x => (x.ParameterName == current.Name));
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
                values[item.ParameterName] = item.Value;

            return values;
        }

        public int Delay { get; set; }

        public int Duration { get; set; }

        [Key] public Guid Id { get; set; }

        public string Name { get; set; }

        public RundownSequenceType.EType SequenceType { get; set; }


        public ICollection<ElementValue> Values { get; protected set; } = new List<ElementValue>();

        public RundownFunction Function { get; protected set; }




        [ComplexType]
        public class ElementValue
        {
            protected ElementValue() { }

            internal ElementValue([NotNull] RundownParameter parameter, string value)
            {
                ParameterName = parameter.Name;
                Value = value;
            }

            public void SetValue(string value) => Value = value;

            public string ParameterName { get; protected set; }

            [Column(nameof(Element))]
            public Guid ElementId { get; protected set; }
            [ForeignKey(nameof(ElementId))]
            public RundownElement Element { get; protected set; }

            public string Value { get; set; }



        }


    }
}