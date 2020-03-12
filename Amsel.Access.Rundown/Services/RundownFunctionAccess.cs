using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Access.Rundown.Services
{
    public class RundownFunctionAccess : CRUDAccess<RundownFunctionDTO>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.FUNCTION;

        #region  CONSTRUCTORS

        public RundownFunctionAccess(IAuthenticationService authenticationService) : base(authenticationService)
        {
        }
        #endregion
    }
}