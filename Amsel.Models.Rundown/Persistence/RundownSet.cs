using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
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
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    public class RundownSet : LogicEntity, ITenantEntity, INamedEntity
    {
        protected RundownSet() { }


        public RundownSet([NotNull] string name, RundownQueue queue, params RundownElement[] elementList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Queue = queue;

            if (elementList != null)
                Elements = elementList.ToList();
        }

        public virtual void AddSequences(params RundownSequence[] rundownSequences)
        {
            foreach (RundownSequence sequence in rundownSequences)
            {
                AddSequence(sequence);
            }
        }

        [Display(Name = nameof(Description))]
        public virtual string Description { get; set; }

        public virtual string Directory { get; set; }

        [NotNull]
        [ItemNotNull]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();

        [Display(Name = nameof(Name))]
        [Required(ErrorMessage = "Field should not be empty")]
        [NotNull] public virtual string Name { get; set; }

        [Range(0, 100)]
        [Display(Name = nameof(Priority))]
        public virtual int Priority { get; set; }

        [Required]
        public virtual RundownQueue Queue { get; set; }

        [NotNull]
        [ItemNotNull]
        public virtual ICollection<RundownSetSequence> CurrentSequences { get; set; } = new List<RundownSetSequence>();

        public void AddSequence(RundownSequence sequence)
        {
            if (CurrentSequences.All(x => x.RundownSequenceId != sequence.Id))
                CurrentSequences.Add(new RundownSetSequence(sequence));
        }

        [NotMapped]
        public ERundownStatus Status { get; set; }

        [Key]
        public Guid Id { get; set; }

        public virtual TenantEntity Tenant { get; set; }


        [Table("RundownSets_Sequences")]
        public class RundownSetSequence
        {
            [Column(nameof(RundownSequence))]
            public Guid RundownSequenceId { get; set; }
            [Required, ForeignKey(nameof(RundownSequenceId))]
            public RundownSequence RundownSequence { get; set; }

            [Column(nameof(RundownSet))]
            public Guid RundownSetId { get; set; }
            [Required, ForeignKey(nameof(RundownSetId))]
            public RundownSet RundownSet { get; set; }

            public ICollection<RundownSequenceValue> SequenceValues { get; protected set; } = new List<RundownSequenceValue>();
            protected RundownSetSequence() { }
            internal RundownSetSequence(RundownSequence sequence, params RundownSequenceValue[] values)
            {
                RundownSequence = sequence;
                if (values != null)
                    SequenceValues = values;
            }

            [Owned, ComplexType]
            [Table("RundownSets_Sequences_Value")]
            public class RundownSequenceValue : RundownValue
            {
                protected RundownSequenceValue() { }

                public RundownSequenceValue([NotNull] RundownParameter parameter, string value) : base(parameter, value)
                {
                }

                [Column(nameof(RundownSequence))]
                public Guid RundownSequenceId { get; set; }
                [Required, ForeignKey(nameof(RundownSequenceId))]
                public RundownSequence RundownSequence { get; set; }

                [Column(nameof(RundownSet))]
                public Guid RundownSetId { get; set; }
                [Required, ForeignKey(nameof(RundownSetId))]
                public RundownSet RundownSet { get; set; }
            }
        }
    }
}