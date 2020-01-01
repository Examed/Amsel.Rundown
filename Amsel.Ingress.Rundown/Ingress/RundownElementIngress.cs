using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Ingress.Authentication.Ingress;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Ingress.Rundown.Ingress
{
    public class RundownElementIngress : CRUDIngress<RundownElementDTO>
    {
        #region  CONSTRUCTORS

        public RundownElementIngress(IAuthService authenticationService) : base(authenticationService) { }

        #endregion

        /// <inheritdoc />
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        /// <inheritdoc />
        protected override string Resource => RundownEndpointResources.RUNDOWN_ELEMENT;
    }
}