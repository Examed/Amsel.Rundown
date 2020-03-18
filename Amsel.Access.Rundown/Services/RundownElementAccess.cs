using Amsel.Access.Authentication.Services;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models;
using Amsel.Models.Rundown.Models;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Access.Rundown.Services
{
    public class RundownElementAccess : CRUDAccess<RundownElement>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.ELEMENT;


        protected override bool RequestLocal => false;
        #region  CONSTRUCTORS

        public RundownElementAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) { }
        #endregion
    }
}