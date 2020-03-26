using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
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

        public void AddData(DonationData donationData1, DonationData donationData2) => throw new NotImplementedException();

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
        public virtual ICollection<RundownSetSequences> SequenceUsage { get; set; } = new List<RundownSetSequences>();

        public IEnumerable<Guid> Sequences => SequenceUsage.Select(x => x.RundownSequenceId);

        public void AddSequence(RundownSequence sequence)
        {
            if (!Sequences.Contains(sequence.Id))
                SequenceUsage.Add(new RundownSetSequences(sequence));
        }

        [NotMapped]
        public ERundownStatus Status { get; set; }

        [Key]
        public Guid Id { get; set; }

        public virtual TenantEntity Tenant { get; set; }


        [Table("RundownSets_Sequences")]
        public class RundownSetSequences
        {
            [Column(nameof(RundownSequence))]
            public Guid RundownSequenceId { get; protected set; }
            [ForeignKey(nameof(RundownSequenceId))]
            public RundownSequence RundownSequence { get; set; }

            [Column(nameof(RundownSet))]
            public Guid RundownSetId { get; protected set; }
            [ForeignKey(nameof(RundownSetId))]
            public RundownSet RundownSet { get; set; }

            protected RundownSetSequences() { }
            internal RundownSetSequences(RundownSequence sequence)
            {
                RundownSequence = sequence;
                RundownSequenceId = sequence.Id;
            }
        }
    }
}