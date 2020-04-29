using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Interfaces;
using Amsel.Model.Tenant.Interfaces;
using Amsel.Model.Tenant.TenantModels;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;

namespace Amsel.Models.Rundown.Persistence {
    /// <inheritdoc cref="GuidEntity"/>
    /// <summary>
    /// A representation of a Action
    /// </summary>
    [ComplexType]
    public class RundownFunction : LogicEntity, ISharedTenant, INamedEntity, IEqualExpression<RundownFunction>
    {
        protected RundownFunction() { }

        public RundownFunction(string name, EHandlerType handler, ERundownMode sequenceType = ERundownMode.LOAD, bool isTrigger = false) {
            Name = name;
            IsTrigger = isTrigger;
            HandlerName = handler;
            SequenceType = sequenceType;
        }

        public string Description { get; set; } = string.Empty;
        public EHandlerType HandlerName { get; set; }
        public string Icon { get; set; }
        [Key]
        public Guid Id { get; set; }
        public bool IsPublic { get; set; } = false;
        public bool IsTrigger { get; set; }
        public string Name { get; set; }
        [NotNull]
        public virtual ICollection<RundownParameter> Parameters { get; set; } = new List<RundownParameter>();
        public ERundownMode SequenceType { get; set; }
        [ForeignKey(nameof(TenantId)), JsonIgnore]
        public virtual TenantEntity Tenant { get; set; }
        public Guid? TenantId { get; set; }

        public void AddParameter([NotNull] string name, string value = null, EParameterType type = EParameterType.TEXTBOX, string description = null) {
            RundownParameter current = Parameters.FirstOrDefault(x => x.Name == name);
            if(current != null) {
                throw new InvalidOperationException($"There is already a Parameter with the Name {name}");
            }

            RundownParameter parameter = string.IsNullOrEmpty(value)
                ? (new RundownParameter(name, type, description))
                : (new RundownParameter(name, value, type, description));
            Parameters.Add(parameter);
        }

        #region IEqualExpression methods
        public Expression<Func<RundownFunction, bool>> IsEquals()
            => x => (x.Id == Id) || ((x.HandlerName == HandlerName) && x.Name.Equals(Name, StringComparison.OrdinalIgnoreCase));
        #endregion
    }
}