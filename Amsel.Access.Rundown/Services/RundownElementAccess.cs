using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Base.DTO;
using Amsel.Framework.Structure.Client.Service;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Access.Rundown.Services
{
    public class RundownElementAccess : CRUDAccess<RundownElementDTO>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.ELEMENT;


        protected override bool RequestLocal => false;
        #region  CONSTRUCTORS

        public RundownElementAccess(IAuthenticationService authenticationService, MultiTenantName tenant) : base(tenant, authenticationService) { }
        #endregion
    }
}