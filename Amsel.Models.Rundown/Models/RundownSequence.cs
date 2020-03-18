using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amsel.Models.Rundown.Models
{
    [ComplexType]
    public class RundownSequence : LogicEntity, ISharedTenant, INamedEntity
    {
        public virtual string Description { get; protected set; }

        [NotNull]
        public virtual ICollection<RundownElement> Elements { get; protected set; } = new List<RundownElement>();

        public virtual bool IsBaseSequence { get; set; }

        [NotNull] public virtual string Name { get; set; }

        #region ISharedTenant Members

        public virtual TenantEntity Tenant { get; set; }

        public virtual bool IsPublic { get; set; }

        public virtual bool IsSystem { get; set; }

        public virtual ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();

        #endregion

        #region  CONSTRUCTORS

        public RundownSequence(params RundownElement[] elementList)
        {
            AddElements(elementList);
            IsBaseSequence = true;
        }

        public RundownSequence(string name, params RundownElement[] elementList)
        {
            AddElements(elementList);
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsBaseSequence = false;
        }


        protected RundownSequence() { }

        public virtual void AddElements(params RundownElement[] elementList)
        {
            foreach(RundownElement element in elementList)
            {
                element.Sequence = this;
                Elements.Add(element);
            }
        }
        #endregion
    }
}