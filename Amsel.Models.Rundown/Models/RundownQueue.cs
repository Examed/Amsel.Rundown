using Amsel.Framework.Base.Interfaces;
using Amsel.Framework.Database.SQL.Context;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amsel.Models.Rundown.Models
{
    [ComplexType]
    public class RundownQueue : IGuidEntity, ISharedTenant, INamedEntity
    {
        public Guid Id { get; set; }
        public bool IsPublic { get; set; }

        public bool IsSystem { get; set; }

        [Distinct]
        public string Name { get; set; }
        public TenantEntity Tenant { get; set; }

        public ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();

        public  bool StopOnNew { get; set; }
  
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