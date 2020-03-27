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

    public partial class RundownElement : IGuidEntity, INamedEntity
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
                RundownElementValue parameterValue = Values.FirstOrDefault(x => (x.ParameterName == current.Name));
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
            foreach (RundownValue item in Values)
                values[item.ParameterName] = item.Value;

            return values;
        }

        public int Delay { get; set; }

        public int Duration { get; set; }

        [Key] public Guid Id { get; set; }

        public string Name { get; set; }

        public RundownSequenceType.EType SequenceType { get; set; }


        public ICollection<RundownElementValue> Values { get; protected set; } = new List<RundownElementValue>();

        public RundownFunction Function { get; protected set; }

        [Owned,ComplexType]
        public class RundownElementValue : RundownValue
        {
            protected RundownElementValue() { }

            public RundownElementValue([NotNull] RundownParameter parameter, string value) : base(parameter, value)
            {
            }

            [Column(nameof(Element))]
            public Guid ElementId { get; set; }
            [Required, ForeignKey(nameof(ElementId))]
            public RundownElement Element { get; set; }
        }
    }
}