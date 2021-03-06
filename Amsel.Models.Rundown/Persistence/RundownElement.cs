﻿using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Attributes;
using Amsel.Framework.Base.Interfaces;
using Amsel.Models.Rundown.Models;
using Amsel.Rundown.Domain.Models.LogicEntities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public RundownElement() { }

        public RundownElement(RundownFunction function, ERundownMode? sequenceType = null, int delay = 0) {
            if(sequenceType.HasValue) {
                SequenceType = sequenceType.Value;
            } else if(Function != null) {
                SequenceType = function.SequenceType;
            }

            Function = function;
            Name = function?.Name;
            Delay = delay;
        }

        public int Delay { get; set; } = 0;

        public int Duration { get; set; } = 0;

        [Required, JsonProperty, ForeignKey(nameof(FunctionId))]
        public virtual RundownFunction Function { get; set; }

        public Guid FunctionId { get; set; }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ERundownMode SequenceType { get; set; }

        [CascadeUpdates, CascadeDelete]
        public virtual ICollection<RundownElementValue> Values { get; protected set; } = new List<RundownElementValue>();

        [NotNull]
        public Dictionary<string, string> GetValues(bool onlyEditable = false) {
            Dictionary<string, string> values = Function.Parameters
                .Where(x => x.HasValue || !onlyEditable)
                .ToDictionary(item => item.Name, item => item.Value);
            foreach(RundownValue item in Values) {
                values[item.ParameterName] = item.Value;
            }

            return values;
        }

        public void SetValue(string name, string value) {
            List<RundownParameter> parameters = Function.Parameters.Where(x => x.Name == name).ToList();
            foreach(RundownParameter current in parameters) {
                RundownElementValue parameterValue = Values.FirstOrDefault(x => x.ParameterName == current.Name);
                if(parameterValue == null) {
                    Values.Add(new RundownElementValue(current.Name, value));
                } else {
                    parameterValue.Value = value;
                }
            }
        }

        [Owned, ComplexType]
        public class RundownElementValue : RundownValue
        {
            protected RundownElementValue() { }

            public RundownElementValue([NotNull] string parameterName, string value) : base(parameterName, value) { }
        }
    }
}