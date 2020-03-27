using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Amsel.Models.Rundown.Models.RundownSet;

namespace Amsel.Models.Rundown.Models
{
    [ComplexType]
    public class RundownSequence : LogicEntity, ISharedTenant, INamedEntity
    {
        protected RundownSequence() { }


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

        public void AddElements(params RundownElement[] elementList)
        {
            foreach (RundownElement element in elementList)
            {
                Elements.Add(element);
            }
        }

        public string Description { get; set; }

        [NotNull]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();


        public bool CanEdit(TenantName tenantName)
        {
            return CanEdit(tenantName.ToString());
        }
        public bool CanEdit(string tenantName)
        {
            if (Tenant.TenantName == tenantName)
                return true;
            if (IsSystem)
                return true;
            if (IsPublic && UsedBy.Any(x => x.TenantName == tenantName))
                return true;

            return false;
        }

        [Key]
        public Guid Id { get; set; }

        public bool IsBaseSequence { get; set; }

        public bool IsPublic { get; set; }

        public bool IsSystem { get; set; }

        [NotNull] public string Name { get; set; }

        public virtual TenantEntity Tenant { get; set; }

        [NotMapped]
        public virtual ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();

      
    }
}