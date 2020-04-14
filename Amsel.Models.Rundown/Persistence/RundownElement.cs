using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Attributes;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Amsel.Models.Rundown.Persistence
{
    [Owned, ComplexType]
    public partial class RundownElement : LogicEntity, IGuidEntity, INamedEntity
    {
        public int Delay { get; set; }

        public int Duration { get; set; }

        public virtual RundownFunction Function { get; protected set; }

        [Key] public Guid Id { get; set; }

        public string Name { get; set; }

        public ERundownMode SequenceType { get; set; }

        [CascadeUpdates]
        public virtual ICollection<RundownElementValue> Values { get; protected set; } = new List<RundownElementValue>();

        public RundownElement() { }

        public RundownElement(RundownFunction function, ERundownMode? sequenceType = null, int delay = 0)
        {
            SequenceType = sequenceType ?? function.SequenceType;
            Function = function;
            Name = function.Name;
            Delay = delay;
        }

        #region PUBLIC METHODES
        public void AddValue([NotNull] string name, string value)
        {
            List<RundownParameter> parameter = Function.Parameters.Where(x => x.Name == name).ToList();
            foreach (RundownParameter current in parameter)
            {
                RundownElementValue parameterValue = Values.FirstOrDefault(x => x.ParameterName == current.Name);
                if (parameterValue == null)
                    parameterValue = new RundownElementValue(current.Name, value);
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
        #endregion

        [Owned, ComplexType]
        public class RundownElementValue : RundownValue
        {
            protected RundownElementValue() { }
            public RundownElementValue([NotNull] string parameterName, string value) : base(parameterName, value) { }
        }
    }
}