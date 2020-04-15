using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Amsel.Models.Rundown.Persistence
{
    [ComplexType]
    public class RundownSequence : LogicEntity, ISharedTenant, INamedEntity, IGuidEntity, IEqualExpression<RundownSequence>
    {
        public string Description { get; set; }

        [NotNull]
        public virtual ICollection<RundownElement> Elements { get; set; } = new List<RundownElement>();

        [Key]
        public Guid Id { get; set; }

        public bool IsPublic { get; set; } = false;

        [NotNull] public string Name { get; set; }

        [ForeignKey(nameof(TenantId)), JsonIgnore]
        public virtual TenantEntity Tenant { get; set; }

        public Guid? TenantId { get; set; }

        protected RundownSequence() { }

        public RundownSequence(string name, params RundownElement[] elementList)
        {
            AddElements(elementList);
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        #region PUBLIC METHODES
        public void AddElements(params RundownElement[] elementList)
        {
            if(elementList == null)
                return;

            foreach(RundownElement element in elementList)
            {
                Elements.Add(element);
            }
        }

        public Expression<Func<RundownSequence, bool>> IsEquals() => x => (x.Id == Id) ||
            x.Name.Equals(Name, StringComparison.OrdinalIgnoreCase);
        #endregion
    }
}