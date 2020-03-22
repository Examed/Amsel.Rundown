using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using Amsel.Framework.Database.SQL.Context;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Amsel.Models.Rundown.Models
{
    /// <inheritdoc cref="GuidEntity"/>
    /// <summary>
    /// A representation of a Action
    /// </summary>
     [ComplexType]
    public class RundownFunction : LogicEntity, ISharedTenant,INamedEntity
    {
        public virtual string Description { get; set; } = string.Empty;
        
        [Distinct]
        public virtual EHandlerType HandlerName { get; protected set; }

        public virtual string Icon { get; protected set; }

        /// <inheritdoc/>
        public virtual bool IsPublic { get; set; }

        /// <inheritdoc/>
        public virtual bool IsSystem { get; set; }

        public virtual bool IsTrigger { get; set; }

        [Distinct]

        public virtual string Name { get; set; }

        [NotNull]
        public virtual ICollection<RundownParameter> Parameters { get; protected set; } = new List<RundownParameter>();

        public virtual RundownSequenceType.EType SequenceType { get; set; }

        public virtual TenantEntity Tenant { get; set; }

      
        public virtual ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();

        #region PUBLIC METHODES
        public virtual void AddParameter([NotNull] string name, string value = null, EParameterType type = EParameterType.TEXTBOX, string description = null)
        {
            RundownParameter current = Parameters.FirstOrDefault(x => x.Name == name);
            if(current != null)
                throw new InvalidOperationException($"There is already a Parameter with the Name {name}");

            RundownParameter parameter = string.IsNullOrEmpty(value)
                ? (new RundownParameter(name, type, description))
                : (new RundownParameter(name, value, type, description));
            Parameters.Add(parameter);
        }
        #endregion

        #region  CONSTRUCTORS

        public RundownFunction(string name, EHandlerType handler, RundownSequenceType.EType sequenceType = RundownSequenceType.EType.LOAD, bool isTrigger = false)
        {
            Name = name;
            IsTrigger = isTrigger;
            HandlerName = handler;
            SequenceType = sequenceType;
        }

        protected RundownFunction()
        {
        }
        #endregion
    }
}