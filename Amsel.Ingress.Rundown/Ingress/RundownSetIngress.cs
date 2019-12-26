using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amsel.DTO.Rundown.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Ingress.Authentication.Ingress;
using Amsel.Resources.Authentication.Controller;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Ingress.Rundown.Ingress
{
    public class RundownSetIngress : CRUDIngress<RundownSetDTO>
    {
        #region STATICS, CONST and FIELDS

        [NotNull]
        private static readonly APIAddress GetByConnection = new APIAddress(RundownEndpointResources.ENDPOINT,
                                                                            RundownEndpointResources.RUNDOWN_SET, RundownSetControllerResources.ENQUEUE_BY_CONNECTION);

        #endregion

        #region  CONSTRUCTORS

        public RundownSetIngress(IAuthService authenticationService) : base(authenticationService) { }

        #endregion

        /// <inheritdoc />
        protected override APIAddress ReadAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_SET, CRUDControllerResources.READ);


        /// <inheritdoc />
        protected override APIAddress InsertAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_SET, CRUDControllerResources.INSERT);


        /// <inheritdoc />
        protected override APIAddress UpdateAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_SET, CRUDControllerResources.UPDATE);


        /// <inheritdoc />
        protected override APIAddress RemoveAddress => new APIAddress(RundownEndpointResources.ENDPOINT, RundownEndpointResources.RUNDOWN_SET, CRUDControllerResources.REMOVE);

        public Task<HttpResponseMessage> QueueConnectionAsync(EHandlerType handlerType, [NotNull] string functionName, [NotNull] Dictionary<string, string> values) {
            if (functionName == null) throw new ArgumentNullException(nameof(functionName));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (!Enum.IsDefined(typeof(EHandlerType), handlerType))
                throw new InvalidEnumArgumentException(nameof(handlerType), (int) handlerType, typeof(EHandlerType));

            RundownConnectionDTO data = new RundownConnectionDTO(handlerType, functionName, values);
          
            return PostAsync(GetByConnection, GetJsonContent(data));
        }
    }
}