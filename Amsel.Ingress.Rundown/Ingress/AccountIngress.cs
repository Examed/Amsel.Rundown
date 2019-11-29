using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amsel.DTO.Authentication.Models;
using Amsel.DTO.Rundown.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Infrastruktur.Application.Interfaces;
using Amsel.Framework.Infrastruktur.Application.Models.Address;
using Amsel.Framework.Infrastruktur.Application.Service;
using Amsel.Framework.Utilities.Extentions.Http;
using Amsel.Resources.Authentication.Controller;
using Amsel.Resources.Authentication.Endpoints;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Amsel.Ingress.Authentication.Ingress
{
    public class RundownSetIngress : GenericIngress
    {
        #region STATICS, CONST and FIELDS

        [NotNull]
        private static readonly APIAddress GetByConnection = new APIAddress(RundownEndpointResources.ENDPOINT,
            RundownEndpointResources.RUNDOWN_SET,
            RundownSetControllerResources.ENQUEUE_BY_CONNECTION);

        #endregion

        #region  CONSTRUCTORS

        public RundownSetIngress(IAuthService authenticationService) : base(authenticationService)
        {

        }

        #endregion

        [NotNull]
        public async void QueueConnection(EHandlerType handlerType, [NotNull] string functionName, [NotNull] Dictionary<string, string> values)
        {
            if (functionName == null) throw new ArgumentNullException(nameof(functionName));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (!Enum.IsDefined(typeof(EHandlerType), handlerType))
                throw new InvalidEnumArgumentException(nameof(handlerType), (int)handlerType, typeof(EHandlerType));

            var data = new RundownConnectionDTO(handlerType, functionName, values);
            var json = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            await PostAsync(GetByConnection, stringContent);
        }
    }
}