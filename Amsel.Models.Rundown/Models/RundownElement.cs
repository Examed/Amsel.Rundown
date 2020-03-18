using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amsel.Models.Rundown.Models
{
    /// <inheritdoc cref="GuidEntity"/>
    /// <summary>
    /// An Implementation of a RundownFunction
    /// </summary>
    public class RundownElement : LogicEntity
    {
        public  int Delay { get; set; }

        public  int Duration { get; protected set; }

        public RundownFunction Function { get; protected set; }

        public  string Name { get; set; }

        public RundownSequence Sequence { get; set; }

        public  RundownSequenceType.EType SequenceType { get; protected set; }

        public ICollection<RundownElementValue> Values { get; protected set; } = new List<RundownElementValue>();

        #region PUBLIC METHODES
        public  void AddValue([NotNull] string name, string value)
        {
            List<RundownParameter> parameter = Function.Parameters.Where(x => x.Name == name).ToList();
            foreach (RundownParameter current in parameter)
            {
                RundownElementValue parameterValue = Values.FirstOrDefault(x => (x?.Parameter != null) &&
                    (x.Parameter.Id == current.Id));
                if (parameterValue == null)
                    parameterValue = new RundownElementValue(current, value);
                else
                    parameterValue.SetValue(value);

                Values.Add(parameterValue);
            }
        }

        [NotNull]
        public  Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> values = Function.Parameters.ToDictionary(item => item.Name, item => item.Value);
            foreach (RundownElementValue item in Values)
                values[item.Parameter.Name] = item.Value;

            return values;
        }
        #endregion

        #region Nested type: RundownElementValue

        public class RundownElementValue : IGuidEntity
        {

            internal RundownElementValue([NotNull] RundownParameter parameter, string value)
            {
                Parameter = parameter;
                Value = value;
            }

            protected RundownElementValue() { }

            [NotNull]
            public RundownParameter Parameter { get; protected set; }
            public Guid Id { get; protected set; }
            public  string Value { get; protected set; }

            public  void SetValue(string value) => Value = value;
        }

        #endregion

        #region  CONSTRUCTORS

        public RundownElement(RundownFunction function, RundownSequenceType.EType? sequence = null, int delay = 0)
        {
            SequenceType = sequence ?? function.SequenceType;
            Function = function;
            Name = function.Name;
            Delay = delay;
        }


        protected RundownElement()
        {
        }
        #endregion
    }
}