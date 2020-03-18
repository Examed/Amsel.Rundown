using Amsel.Access.Authentication.Services;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models;
using Amsel.Models.Rundown.Models;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Access.Rundown.Services
{
    public class RundownFunctionAccess : CRUDAccess<RundownFunction>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.FUNCTION;

        #region  CONSTRUCTORS
        protected override bool RequestLocal => false;
        public RundownFunctionAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) {  }
        #endregion
    }
}