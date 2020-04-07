using Amsel.Framework.Composites.Models;
using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.DTOs;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services
{
    public class RundownCompositesAccess : CRUDAccess<CompositeComponent>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.COMPOSITES;


        private UriBuilder GetCompositesAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownCompositeControllerResources.GET_ALL, RequestLocal);
        private UriBuilder GetComponentsAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownCompositeControllerResources.GET_COMPONENTS, RequestLocal);

        public RundownCompositesAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService)
        { }

        #region PUBLIC METHODES
        public virtual async Task<IEnumerable<CompositeComponent>> GetCompositesAsync()
        {
            HttpResponseMessage response = await GetAsync(GetCompositesAddress).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<CompositeComponent>>().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<CompositeComponent>> GetComponentsAsync(CompositeComponent composite)
        {
            return await GetComponentsAsync(composite.Id);
        }
        public virtual async Task<IEnumerable<CompositeComponent>> GetComponentsAsync(Guid? id)
        {
            HttpResponseMessage response = await GetAsync(GetComponentsAddress, ("id", id)).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<CompositeComponent>>().ConfigureAwait(false);
        }

        private UriBuilder UpdateComponentParentAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownCompositeControllerResources.UPDATE_PARENT, RequestLocal);

        public virtual async Task<bool> UpdateComponentParent(CompositeComponent component, Guid? newParentId)
        {
            var updateDTO = new UpdateCompositeParentDTO(component, newParentId);
            HttpResponseMessage response = await PostAsync(UpdateComponentParentAddress, GetJsonContent(updateDTO)).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
        #endregion
    }
}