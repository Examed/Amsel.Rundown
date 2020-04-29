using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Persistence;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services {
    public class RundownFunctionAccess : CRUDAccess<RundownFunction>
    {
        public RundownFunctionAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) {
        }

        public UriBuilder GetByHandlerAddress
            => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownFunctionControllerResources.GET_BY_HANDLER, RequestLocal);
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;
        protected override bool RequestLocal => false;
        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.FUNCTION;

        public async Task<IEnumerable<RundownFunction>> GetByHandlerAsync(EHandlerType handler) {
            HttpResponseMessage response = await GetAsync(GetByHandlerAddress, (nameof(handler), handler.ToString())).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<RundownFunction>>().ConfigureAwait(false);
        }
    }
}