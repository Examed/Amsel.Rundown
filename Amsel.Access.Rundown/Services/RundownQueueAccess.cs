using Amsel.Framework.Base.Models;
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

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.QUEUE;

        public async Task<IEnumerable<GuidNameEntity>> GetQueueNamesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetQueueNamesAddress).ConfigureAwait(false);
            return await response.DeserializeElseThrowAsync<IEnumerable<GuidNameEntity>>().ConfigureAwait(false);
        }
    }
}