using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;

namespace Amsel.Access.Rundown.Services
{
    public class RundownSequenceAccess : CRUDAccess<RundownSequenceDTO>
    {
        #region  CONSTRUCTORS

        public RundownSequenceAccess(IAuthenticationService authenticationService) : base(authenticationService) { }

        #endregion

        /// <inheritdoc />
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc />
        protected override string Resource => RundownEndpointResources.SEQUENCE;       
    }

     public class RundownQueueAccess : CRUDAccess<RundownQueueDTO>
    {
        #region  CONSTRUCTORS

        public RundownQueueAccess(IAuthenticationService authenticationService) : base(authenticationService) { }

        #endregion

        /// <inheritdoc />
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc />
        protected override string Resource => RundownEndpointResources.QUEUE;
        [NotNull] protected virtual APIAddress GetQueueNamesAddress => new APIAddress(Endpoint, Resource, RundownQueueControllerResources.GET_QUEUE_NAMES);

        public async Task<IEnumerable<(Guid Id, string Name)>> GetQueueNamesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetQueueNamesAddress).ConfigureAwait(false);
            return await response.DeserializeElseThrowAsync<IEnumerable<(Guid Id, string Name)>>().ConfigureAwait(false);
        }
    }
}