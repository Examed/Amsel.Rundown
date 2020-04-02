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

namespace Amsel.Models.Rundown.Models
{
    public class RundownSetBase : LogicEntity, INamedEntity, IGuidEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = nameof(Description))]
        public virtual string Description { get; set; }

        public virtual string Directory { get; set; }
        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        [NotNull] public virtual string Name { get; set; }
        [Required]
        public virtual RundownQueue Queue { get; set; }
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
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Queue = queue;

            if (elementList != null)
                Elements = elementList.ToList();
        }

        [Range(0, 100)]
        [Display(Name = nameof(Priority))]
        public virtual int Priority { get; set; }

        [NotNull]
        [ItemNotNull]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();

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
                protected RundownSequenceValue() { }

                public RundownSequenceValue([NotNull] RundownParameter parameter, string value) : base(parameter, value)
                {
                }
            }
        }
    }
}