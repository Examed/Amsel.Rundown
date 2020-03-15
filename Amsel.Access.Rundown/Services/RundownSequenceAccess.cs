using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Structure.Client.Service;
using Amsel.Framework.Structure.Models;

namespace Amsel.Access.Rundown.Services
{
    public class RundownSequenceAccess : CRUDAccess<RundownSequenceDTO>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.SEQUENCE;

        #region  CONSTRUCTORS

        public RundownSequenceAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService)
            {  }

        #endregion

        [NotNull] private UriBuilder GetByRundownAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSequenceControllerResources.GET_BY_RUNDOWN, RequestLocal);

        protected override bool RequestLocal => false;

        public virtual async Task<IEnumerable<RundownSequenceDTO>> GetSequencesByRundown(Guid id)
        {
            HttpResponseMessage response = await GetAsync(GetByRundownAddress, (nameof(id), id)).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<RundownSequenceDTO>>().ConfigureAwait(false);
        }
    }
}