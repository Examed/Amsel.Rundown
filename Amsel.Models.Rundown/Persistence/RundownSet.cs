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
                if (Sequences.All(x => x.Id != sequence.Id))
                    Sequences.Add(sequence);
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
        public virtual ICollection<RundownSequence> Sequences { get; set; } = new List<RundownSequence>();

        [NotMapped]
        public ERundownStatus Status { get; set; }

        [Key]
        public Guid Id { get; set; }

        public virtual TenantEntity Tenant { get; set; }
    }
}