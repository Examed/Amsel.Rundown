using Amsel.Access.Authentication.Services;
using Amsel.Framework.Base.Models;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Framework.Utilities.Extensions.Http;
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
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        [NotNull] protected virtual UriBuilder GetQueueNamesAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownQueueControllerResources.GET_NAMES, RequestLocal);

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.QUEUE;

        protected override bool RequestLocal =>false;

        public RundownQueueAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) { }

        #region PUBLIC METHODES
        public async Task<IEnumerable<GuidNameEntity>> GetQueueNamesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetQueueNamesAddress).ConfigureAwait(false);
            return await response.DeserializeElseThrowAsync<IEnumerable<GuidNameEntity>>().ConfigureAwait(false);
        }
        #endregion
    }
}