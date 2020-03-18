using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using System;
using System.Collections.Generic;

namespace Amsel.Models.Rundown.Models
{
    public class RundownQueue : IGuidEntity, ISharedTenant, INamedEntity
    {
        public  bool IsPublic { get; set; }

        /// <inheritdoc/>
        public  bool IsSystem { get; set; }

        public  string Name { get; set; }

        public  bool StopOnNew { get; set; }

        public  Guid Id { get; set; }

        public  TenantEntity Tenant { get; set; }

        public ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();
  
        #region  CONSTRUCTORS

        public RundownQueue(string name, bool stopOnNew = false, bool isPublic = false)
        {
            Name = name;
            StopOnNew = stopOnNew;
            IsPublic = isPublic;
        }

        protected RundownQueue()
        {
        }
        #endregion
    }
}