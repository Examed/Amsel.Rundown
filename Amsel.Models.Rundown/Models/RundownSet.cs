using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amsel.Models.Rundown.Models
{
    /// <inheritdoc cref="GuidEntity"/>
    /// <summary>
    /// RundownCollection contains a set of RundownElements that get played when the Collection is active
    /// </summary>
    public class RundownSet : LogicEntity, IMultiTenant, INamedEntity
    {
        public virtual string Description { get; protected set; }

        public virtual string Directory { get; protected set; }

        [NotNull, ItemNotNull]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();

        [NotNull] public virtual string Name { get; set; }

        public virtual int Priority { get; protected set; }
        public virtual RundownQueue Queue { get; set; }

        [NotNull, ItemNotNull]
        public virtual ICollection<RundownSequence> Sequences { get; set; } = new List<RundownSequence>();


        public virtual TenantEntity Tenant { get; set; }
 

        #region  CONSTRUCTORS

        public RundownSet([NotNull] string name, RundownQueue queue, params RundownElement[] elementList)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Queue = queue;

            if (elementList != null)
                Elements = elementList.ToList();
        }


        protected RundownSet() { }

        public virtual void AddSequences(params RundownSequence[] rundownSequences)
        {
            foreach (RundownSequence sequence in rundownSequences)
            {
                if (Sequences.All(x => x.Id != sequence.Id))
                    Sequences.Add(sequence);
            }
        }
        #endregion
    }
}