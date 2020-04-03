using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Amsel.Models.Rundown.Models
{
    [ComplexType]
    public class RundownQueue : IGuidEntity, ISharedTenant, INamedEntity, IEqualExpression<RundownQueue>
    {
        protected RundownQueue() { }

        public RundownQueue(string name, bool stopOnNew = false, bool isPublic = false)
        {
            Name = name;
            StopOnNew = stopOnNew;
            IsPublic = isPublic;
        }

        public Guid Id { get; set; }

        public bool IsPublic { get; set; } = false;


        public string Name { get; set; }

        public bool StopOnNew { get; set; }

        public virtual TenantEntity Tenant { get; set; }


        public Expression<Func<RundownQueue, bool>> IsEquals() => x => x.Id == Id || x.Name.Equals(Name, StringComparison.OrdinalIgnoreCase);
        
    }
}