using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Amsel.Models.Rundown.Persistence {
    [ComplexType]
    public class RundownQueue : IGuidEntity, ISharedTenant, INamedEntity, IEqualExpression<RundownQueue> {
        protected RundownQueue() { }

        public RundownQueue(string name, bool stopOnNew = false, bool isPublic = false) {
            Name = name;
            StopOnNew = stopOnNew;
            IsPublic = isPublic;
        }

        public Guid Id { get; set; }
        public bool IsPublic { get; set; } = false;
        public string Name { get; set; }
        public bool StopOnNew { get; set; }
        [ForeignKey(nameof(TenantId)), JsonIgnore]
        public virtual TenantEntity Tenant { get; set; }
        public Guid? TenantId { get; set; }

        #region IEqualExpression methods
        public Expression<Func<RundownQueue, bool>> IsEquals()
            => x => (x.Id == Id) || x.Name.Equals(Name, StringComparison.OrdinalIgnoreCase);
        #endregion
    }
}