using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;

namespace Amsel.Access.Rundown.Services
{
  
    public class RundownSetAccess : CRUDAccess<RundownSetDTO>
    {
        #region  CONSTRUCTORS

        public RundownSetAccess(IAuthenticationService authenticationService) : base(authenticationService) { }

        #endregion

        #region STATICS, CONST and FIELDS

        [NotNull] private APIAddress GetByConnectionAddress => new APIAddress(Endpoint, Resource, RundownSetControllerResources.ENQUEUE);
              [NotNull] private APIAddress GetByQueueAddress => new APIAddress(Endpoint, Resource, RundownSetControllerResources.GET_BY_QUEUE);

        #endregion

        /// <inheritdoc />
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool Local => false;

        /// <inheritdoc />
        protected override string Resource => RundownEndpointResources.SET;

        public Task<HttpResponseMessage> QueueConnectionAsync(EHandlerType handlerType, [NotNull] string functionName, [NotNull] Dictionary<string, string> values)
        {
            if (functionName == null) throw new ArgumentNullException(nameof(functionName));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (!Enum.IsDefined(typeof(EHandlerType), handlerType))
                throw new InvalidEnumArgumentException(nameof(handlerType), (int) handlerType, typeof(EHandlerType));

            RundownTriggerDTO data = new RundownTriggerDTO(handlerType, values);

            return PostAsync(GetByConnectionAddress, GetJsonContent(data));
        }

        public virtual async Task<(IEnumerable<RundownSetDTO> value, int count)> GetByQueueAsync(string queueName, int? skip = null, int? take = null)
        {
            HttpResponseMessage response = await GetAsync(GetByQueueAddress, (nameof(queueName),queueName), (nameof(skip),skip), (nameof(take),take)).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<(IEnumerable<RundownSetDTO> value, int count)>().ConfigureAwait(false);
        }
    }
}