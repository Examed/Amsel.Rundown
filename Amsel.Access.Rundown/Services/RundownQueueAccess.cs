using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Structure.Client.Service;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services
{
    public class RundownQueueAccess : CRUDAccess<RundownQueueDTO>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        [NotNull] protected virtual UriBuilder GetQueueNamesAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownQueueControllerResources.GET_NAMES, RequestLocal);

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.QUEUE;

        protected override bool RequestLocal =>false;

        public RundownQueueAccess(IAuthenticationService authenticationService, MultiTenantName tenant) : base(tenant, authenticationService) { }

        #region PUBLIC METHODES
        public async Task<IEnumerable<GuidNameEntityDTO>> GetQueueNamesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetQueueNamesAddress).ConfigureAwait(false);
            return await response.DeserializeElseThrowAsync<IEnumerable<GuidNameEntityDTO>>().ConfigureAwait(false);
        }
        #endregion
    }
}