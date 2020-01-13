using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Access.Rundown.Services
{
    public class RundownElementAccess : CRUDAccess<RundownElementDTO>
    {
        #region  CONSTRUCTORS

        public RundownElementAccess(IAuthenticationService authenticationService) : base(authenticationService) { }

        #endregion

        /// <inheritdoc />
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc />
        protected override string Resource => RundownEndpointResources.ELEMENT;
    }
}