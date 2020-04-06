using Amsel.Framework.Base.Attributes;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using Amsel.Models.Rundown.Models;
using AutoMapper;
using Amsel.Framework.Composites.Interfaces;
using Amsel.Framework.Composites.Models;

namespace Amsel.Models.Rundown.Persistence
{
    public class RundownSetBase : LogicEntity, INamedEntity, IGuidEntity, ICompositeEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        [NotNull] public virtual string Name { get; set; }
        [Display(Name = nameof(Tooltip))]
        public string Tooltip { get; set; }
        public virtual string Directory { get; set; }
        public Guid? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual CompositeComponent Parent { get; set; }
    }


    [ComplexType]
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    public class RundownSet : RundownSetBase, ITenantEntity
    {
        protected RundownSet() { }

        public RundownSet([NotNull] string name, RundownQueue queue, params RundownElement[] elementList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(queue));
            Queue = queue ?? throw new ArgumentNullException(nameof(queue));

            if (elementList != null)
                Elements = elementList.ToList();
        }

        [Range(0, 100)]
        [Display(Name = nameof(Priority))]
        public virtual int Priority { get; set; }

        [CascadeUpdates]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();
        [Required]
        public virtual RundownQueue Queue { get; set; }
        public void AddSequence(RundownSequence sequence)
        {
            if (Sequences.All(x => x.RundownSequenceId != sequence.Id))
                Sequences.Add(new RundownSetSequence(sequence));
        }
        public virtual void AddSequences(params RundownSequence[] rundownSequences)
        {
            foreach (RundownSequence sequence in rundownSequences)
            {
                AddSequence(sequence);
            }
        }

        [NotNull]
        [ItemNotNull]
        public virtual ICollection<RundownSetSequence> Sequences { get; set; } = new List<RundownSetSequence>();

        public Guid TenantId { get; set; }
        [ForeignKey(nameof(TenantId))]
        public virtual TenantEntity Tenant { get; set; }

        [Table("RundownSets_Sequences")]
        public class RundownSetSequence
        {
            [JsonProperty(nameof(RundownSequenceId))]
            public Guid RundownSequenceId { get; protected set; }
            [Required, ForeignKey(nameof(RundownSequenceId)), JsonProperty(nameof(RundownSequence))]
            public virtual RundownSequence RundownSequence { get; set; }
            [JsonProperty(nameof(SequenceValues))]
            public virtual ICollection<RundownSequenceValue> SequenceValues { get; protected set; } = new List<RundownSequenceValue>();
            protected RundownSetSequence() { }
            internal RundownSetSequence(RundownSequence rundownSequence, params RundownSequenceValue[] sequenceValues)
            {
                RundownSequence = rundownSequence;
                if (sequenceValues != null)
                    SequenceValues = sequenceValues;
            }

            [Owned, ComplexType]
            [Table("RundownSets_Sequences_Value")]
            public class RundownSequenceValue : RundownValue
            {

                public virtual Guid? ElementId { get; set; }

                protected RundownSequenceValue() { }

                public RundownSequenceValue(Guid elementId, string parameterName, string value) : base(parameterName, value)
                {
                    ElementId = elementId;
                }

                public RundownSequenceValue([NotNull] string parameterName, string value) : base(parameterName, value)
                {
                }
            }
        }
    }
}