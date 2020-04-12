using Amsel.Enums.Rundown.Enums;
using Amsel.Framework.Structure.Factory;
using Amsel.Framework.Structure.Interfaces;
using Amsel.Framework.Structure.Services;
using Amsel.Framework.Utilities.Extensions.Http;
using Amsel.Model.Tenant.TenantModels;
using Amsel.Models.Rundown.Models;
using Amsel.Models.Rundown.Persistence;
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
        /// <inheritdoc/>
        protected override string Endpoint => RundownEndpointResources.ENDPOINT;

        protected override bool RequestLocal => false;

        /// <inheritdoc/>
        protected override string Resource => RundownEndpointResources.SET;

        [NotNull] private UriBuilder GetByConnectionAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSetControllerResources.ENQUEUE, RequestLocal);

        private UriBuilder GetSequencesAddress => UriBuilderFactory.GetAPIBuilder(Endpoint, Resource, RundownSetControllerResources.GET_SEQUENCES, RequestLocal);

        public RundownSetAccess(IAuthenticationService authenticationService, TenantName tenant) : base(tenant, authenticationService)
        { }

        #region PUBLIC METHODES
        public virtual async Task<IEnumerable<RundownSequence>> GetSequences(Guid id)
        {
            HttpResponseMessage response = await GetAsync(GetSequencesAddress, (nameof(id), id)).ConfigureAwait(false);
            return await response.DeserializeOrDefaultAsync<IEnumerable<RundownSequence>>().ConfigureAwait(false);
        }

        public Task<HttpResponseMessage> QueueConnectionAsync(EHandlerType handlerType, [NotNull] string functionName, [NotNull] Dictionary<string, string> values)
        {
            if(functionName == null)
                throw new ArgumentNullException(nameof(functionName));
            if(values == null)
                throw new ArgumentNullException(nameof(values));
            if(!Enum.IsDefined(typeof(EHandlerType), handlerType))
                throw new InvalidEnumArgumentException(nameof(handlerType), (int)handlerType, typeof(EHandlerType));

            RundownTrigger data = new RundownTrigger(handlerType, values);

            return PostAsync(GetByConnectionAddress, GetJsonContent(data));
        }
        #endregion
    }
}