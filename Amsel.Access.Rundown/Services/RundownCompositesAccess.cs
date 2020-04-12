using Amsel.Framework.Composites.Models;
using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services
{
    public class RundownCompositesAccess : CRUDAccess<CompositeEntity>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.COMPOSITES;

        private UriBuilder GetComponentsAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownCompositeControllerResources.GET_COMPONENTS, RequestLocal);

        private UriBuilder GetCompositesAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownCompositeControllerResources.GET_ALL, RequestLocal);

        public RundownCompositesAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService)
        { }

        #region PUBLIC METHODES
        public virtual async Task<IEnumerable<CompositeEntity>> GetComponentsAsync(CompositeEntity composite) => await GetComponentsAsync(composite.Id);

        public virtual async Task<IEnumerable<CompositeEntity>> GetComponentsAsync(Guid? id)
        {
            HttpResponseMessage response = await GetAsync(GetComponentsAddress, (nameof(id), id)).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<CompositeEntity>>().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<CompositeEntity>> GetCompositesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetCompositesAddress).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<CompositeEntity>>().ConfigureAwait(false);
        }
        #endregion
    }
}