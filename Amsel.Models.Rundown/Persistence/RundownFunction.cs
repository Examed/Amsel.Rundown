﻿using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Base.Attributs;
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
    /// <inheritdoc cref="GuidEntity"/>
    /// <summary>
    /// A representation of a Action
    /// </summary>
    [ComplexType]
    public class RundownFunction : LogicEntity, ISharedTenant, INamedEntity
    {
        protected RundownFunction() { }


        public RundownFunction(string name,
                               EHandlerType handler,
                               RundownSequenceType.EType sequenceType = RundownSequenceType.EType.LOAD,
                               bool isTrigger = false)
        {
            Name = name;
            IsTrigger = isTrigger;
            HandlerName = handler;
            SequenceType = sequenceType;
        }

        public  void AddParameter([NotNull] string name, string value = null, EParameterType type = EParameterType.TEXTBOX, string description = null)
        {
            RundownParameter current = Parameters.FirstOrDefault(x => x.Name == name);
            if(current != null)
                throw new InvalidOperationException($"There is already a Parameter with the Name {name}");

            RundownParameter parameter = string.IsNullOrEmpty(value)
                ? (new RundownParameter(name, type, description))
                : (new RundownParameter(name, value, type, description));
            Parameters.Add(parameter);
        }

        public  string Description { get; set; } = string.Empty;
        [Key]
        public Guid Id { get; set; }
        [Distinct]
        public  EHandlerType HandlerName { get; protected set; }

        public  string Icon { get; protected set; }

        /// <inheritdoc/>
        public  bool IsPublic { get; set; }

        /// <inheritdoc/>
        public  bool IsSystem { get; set; }

        public  bool IsTrigger { get; set; }

        [Distinct]
        public  string Name { get; set; }

        [NotNull]
        public  ICollection<RundownParameter> Parameters { get; protected set; } = new List<RundownParameter>();

        public  RundownSequenceType.EType SequenceType { get; set; }

        public  TenantEntity Tenant { get; set; }

        [NotMapped]
        public  ICollection<TenantEntity> UsedBy { get; set; } = new List<TenantEntity>();
    }
}