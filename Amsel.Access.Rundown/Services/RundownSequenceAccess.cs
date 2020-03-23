using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Models;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services
{
    public class RundownSequenceAccess : CRUDAccess<RundownSequence>
    {
        public RundownSequenceAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) { }


        [NotNull]
        UriBuilder GetByRundownAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSequenceControllerResources.GET_BY_RUNDOWN, RequestLocal);

        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.SEQUENCE;

        public virtual async Task<IEnumerable<RundownSequence>> GetSequencesByRundown(Guid id)
        {
            HttpResponseMessage response = await GetAsync(GetByRundownAddress, (nameof(id), id)).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<RundownSequence>>().ConfigureAwait(false);
        }
    }
}