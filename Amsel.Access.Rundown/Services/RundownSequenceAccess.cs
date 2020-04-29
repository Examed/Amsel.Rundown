using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Persistence;
using Amsel.Resources.Rundown.Endpoints;
using System;

namespace Amsel.Access.Rundown.Services {
    public class RundownSequenceAccess : CRUDAccess<RundownSequence>
    {
        public RundownSequenceAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) {
        }

        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;
        protected override bool RequestLocal => false;
        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.SEQUENCE;
    }
}