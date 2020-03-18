using Amsel.Access.Authentication.Services;
using Amsel.DTO.Rundown.Models;
using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Models.Address;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Amsel.Framework.Structure.Models;
using Amsel.Models.Rundown.Models;

namespace Amsel.Access.Rundown.Services
{
    public class RundownSetAccess : CRUDAccess<RundownSet>
    {
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.SET;

        #region  CONSTRUCTORS

        public RundownSetAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) { }

        #endregion

        #region PUBLIC METHODES
        public virtual async Task<(IEnumerable<RundownSet> value, int count)> GetByQueueAsync(string queueName, int? skip = null, int? take = null)
        {
            HttpResponseMessage response = await GetAsync(GetByQueueAddress, (nameof(queueName), queueName), (nameof(skip), skip), (nameof(take), take))
                                                     .ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<(IEnumerable<RundownSet> value, int count)>()
                             .ConfigureAwait(false);
        }


        public Task<HttpResponseMessage> QueueConnectionAsync(EHandlerType handlerType, [NotNull] string functionName, [NotNull] Dictionary<string, string> values)
        {
            if (functionName == null)
                throw new ArgumentNullException(nameof(functionName));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (!Enum.IsDefined(typeof(EHandlerType), handlerType))
                throw new InvalidEnumArgumentException(nameof(handlerType), (int)handlerType, typeof(EHandlerType));

            RundownTrigger data = new RundownTrigger(handlerType, values);

            return PostAsync(GetByConnectionAddress, GetJsonContent(data));
        }
        #endregion

        #region STATICS, CONST and FIELDS

        [NotNull] private UriBuilder GetByConnectionAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSetControllerResources.ENQUEUE, RequestLocal);
        [NotNull] private UriBuilder GetByQueueAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSetControllerResources.GET_BY_QUEUE, RequestLocal);

        #endregion
    }
}