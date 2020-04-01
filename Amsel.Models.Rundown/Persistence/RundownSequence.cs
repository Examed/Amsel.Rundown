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
    public class RundownSequence : LogicEntity, ISharedTenant, INamedEntity, IGuidEntity
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




        [Key]
        public Guid Id { get; set; }

        public bool IsBaseSequence { get; set; }

        public bool IsPublic { get; set; } = false;


        [NotNull] public string Name { get; set; }

        public virtual TenantEntity Tenant { get; set; }

     

    }
}