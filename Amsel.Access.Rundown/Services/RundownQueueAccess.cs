using Amsel.Framework.Base.Models;
using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Resources;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Persistence;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services
{
    public class RundownQueueAccess : CRUDAccess<RundownQueue>
    {
        public RundownQueueAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) { }

        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        [NotNull]
        protected virtual UriBuilder GetQueueNamesAddress => UriBuilderFactory.GetAPIBuilder(Endpoint,
                                                                                             Resource,
                                                                                             RundownQueueControllerResources.GET_NAMES,
                                                                                             RequestLocal);
        [NotNull] UriBuilder GetRundownSetsAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownQueueControllerResources.GET_RUNDOWNS, RequestLocal);
        [NotNull] UriBuilder GetAllAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownQueueControllerResources.GET_ALL, RequestLocal);
        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.QUEUE;

        public async Task<IEnumerable<GuidNameEntity>> GetQueueNamesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetQueueNamesAddress).ConfigureAwait(false);
            return await response.DeserializeElseThrowAsync<IEnumerable<GuidNameEntity>>().ConfigureAwait(false);
        }
        public async Task<IEnumerable<RundownQueue>> GetAllAsync()
        {
            HttpResponseMessage response = await GetAsync(GetAllAddress).ConfigureAwait(false);
            return await response.DeserializeElseThrowAsync<IEnumerable<RundownQueue>>().ConfigureAwait(false);
        }

        public virtual IEnumerable<RundownSet> GetRundownSets(Guid Id)
        {
            return GetRundownSetsAsync(Id).Result;
        }

        public virtual async Task<IEnumerable<RundownSet>> GetRundownSetsAsync(Guid Id)
        {
            HttpResponseMessage response = await GetAsync(GetRundownSetsAddress, (nameof(Id), Id))
                .ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<RundownSet>>().ConfigureAwait(false);
        }
    }
}