using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Models;
using Amsel.Resources.Rundown.Controller;
using Amsel.Resources.Rundown.Endpoints;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Amsel.Access.Rundown.Services
{
    public class RundownSetAccess : CRUDAccess<RundownSet>
    {
        public RundownSetAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService) { }


        [NotNull] UriBuilder GetByConnectionAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSetControllerResources.ENQUEUE, RequestLocal);

        [NotNull] UriBuilder GetByQueueAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSetControllerResources.GET_BY_QUEUE, RequestLocal);

        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.SET;



        public virtual IEnumerable<RundownSet> GetByQueue(string queueName, int? skip = null, int? take = null)
        {
            return GetByQueueAsync(queueName, skip, take).Result;
        }

        public virtual async Task<IEnumerable<RundownSet>> GetByQueueAsync(string queueName, int? skip = null, int? take = null)
        {
            HttpResponseMessage response = await GetAsync(GetByQueueAddress, (nameof(queueName), queueName), (nameof(skip), skip), (nameof(take), take))
                .ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<RundownSet>>().ConfigureAwait(false);
        }
                

        public Task<HttpResponseMessage> QueueConnectionAsync(EHandlerType handlerType,
                                                              [NotNull] string functionName,
                                                              [NotNull] Dictionary<string, string> values)
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
    }
}