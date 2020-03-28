using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Amsel.Models.Rundown.Models
{
    [ComplexType]
    public class RundownQueue : IGuidEntity, ISharedTenant, INamedEntity, ILinqEqual<RundownQueue>
    {
        protected RundownQueue() { }

        public RundownQueue(string name, bool stopOnNew = false, bool isPublic = false)
        {
            Name = name;
            StopOnNew = stopOnNew;
            IsPublic = isPublic;
        }

        public Guid Id { get; set; }

        public bool IsPublic { get; set; }

        public bool IsSystem { get; set; }

        public string Name { get; set; }

        public bool StopOnNew { get; set; }

        public virtual TenantEntity Tenant { get; set; }

        [NotMapped]
        public virtual ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();
                
        public Expression<Func<RundownQueue, bool>> LinqEquals => x => x.Id == Id || x.Name.Equals(Name, StringComparison.OrdinalIgnoreCase);
    }
}