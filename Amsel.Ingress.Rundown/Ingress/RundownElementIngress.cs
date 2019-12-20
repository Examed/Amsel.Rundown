using Amsel.DTO.Rundown.Models;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Ingress.Authentication.Ingress;
using Amsel.Resources.Authentication.Controller;
using Amsel.Resources.Rundown.Endpoints;

namespace Amsel.Ingress.Rundown.Ingress
{
    public class RundownElementIngress : CRUDIngress<RundownElementDTO>
    {
        #region  CONSTRUCTORS

        public RundownElementIngress(IAuthService authenticationService) : base(authenticationService) { }

        #endregion

        /// <inheritdoc />
        protected override APIAddress ReadAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_ELEMENT, CRUDControllerResources.READ);


        /// <inheritdoc />
        protected override APIAddress InsertAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_ELEMENT, CRUDControllerResources.INSERT);


        /// <inheritdoc />
        protected override APIAddress UpdateAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_ELEMENT, CRUDControllerResources.UPDATE);


        /// <inheritdoc />
        protected override APIAddress RemoveAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_ELEMENT, CRUDControllerResources.REMOVE);
    }
}