using Amsel.Framework.Base.Attributes;
using Amsel.Framework.Base.Interfaces;
using Amsel.Framework.Composites.Interfaces;
using Amsel.Framework.Composites.Models;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Amsel.Models.Rundown.Persistence {
    [ComplexType]
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    public class RundownSet : RundownSetBase, ITenantEntity
    {
        [JsonConstructor]
        protected RundownSet()
        {
        }
        public RundownSet([NotNull] string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

        public RundownSet([NotNull] string name, RundownQueue queue, params RundownElement[] elementList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Queue = queue ?? throw new ArgumentNullException(nameof(queue));

            if(elementList != null)
            {
                Elements = elementList.ToList();
            }
        }

        [CascadeUpdates, CascadeDelete]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();
        [ForeignKey(nameof(ParentId)), JsonIgnore]
        public virtual CompositeComponent Parent { get; set; }
        [Range(0, 100),
        Display(Name = nameof(Priority))]
        public virtual int Priority { get; set; } = 30;
        [ForeignKey(nameof(QueueId)), JsonIgnore]
        public virtual RundownQueue Queue { get; set; }
        [NotNull, CascadeUpdates, CascadeDelete]
        public virtual ICollection<RundownSetSequence> Sequences { get; set; } = new List<RundownSetSequence>();
        [ForeignKey(nameof(TenantId)), JsonIgnore]
        public virtual TenantEntity Tenant { get; set; }
        public Guid? TenantId { get; set; }

        #region public methods
        public void AddSequence(RundownSequence sequence)
        {
            if(Sequences.All(x => x.RundownSequenceId != sequence.Id))
            {
                Sequences.Add(new RundownSetSequence(sequence));
            }
        }

        public virtual void AddSequences(params RundownSequence[] rundownSequences)
        {
            foreach(RundownSequence sequence in rundownSequences)
            {
                AddSequence(sequence);
            }
        }

        public void RemoveSequence(RundownSequence sequence) => RemoveSequence(sequence.Id);

        public void RemoveSequence(Guid Id)
        {
            foreach(RundownSetSequence item in Sequences.Where(x => x.RundownSequenceId == Id).ToList())
            {
                Sequences.Remove(item);
            }
        }
        #endregion

        [Table("RundownSets_Sequences")]
        public class RundownSetSequence
        {
            protected RundownSetSequence()
            {
            }

            internal RundownSetSequence(RundownSequence rundownSequence, params RundownSequenceValue[] sequenceValues)
            {
                RundownSequence = rundownSequence;
                if(sequenceValues != null)
                {
                    SequenceValues = sequenceValues;
                }
            }

            [Required, ForeignKey(nameof(RundownSequenceId)), JsonProperty(nameof(RundownSequence))]
            public virtual RundownSequence RundownSequence { get; set; }
            [JsonProperty(nameof(RundownSequenceId))]
            public Guid RundownSequenceId { get; set; }
            [CascadeUpdates, CascadeDelete,
            JsonProperty(nameof(SequenceValues))]
            public virtual ICollection<RundownSequenceValue> SequenceValues
            { get; protected set;
            } = new List<RundownSequenceValue>();

            [Owned, ComplexType,
            Table("RundownSets_Sequences_Value")]
            public class RundownSequenceValue : RundownValue
            {
                protected RundownSequenceValue()
                {
                }
                public RundownSequenceValue([NotNull] string parameterName, string value) : base(parameterName, value)
                {
                }
                public RundownSequenceValue(Guid elementId, string parameterName, string value) : base(parameterName, value)
                    => ElementId = elementId;

                public virtual Guid? ElementId { get; set; }
            }
        }
    }

    public class RundownSetBase : LogicEntity, INamedEntity, IGuidEntity, ICompositeEntity
    {
        public virtual string Directory { get; set; }
        [Key]
        public Guid Id { get; set; }
        [Display(Name = nameof(Name)),
        Required(ErrorMessage = "Field should not be empty"),
        NotNull]
        public virtual string Name { get; set; }
        public Guid? ParentId { get; set; }
        [Required]
        public virtual Guid? QueueId { get; set; }
        [Display(Name = nameof(Tooltip))]
        public string Tooltip { get; set; }
    }
}