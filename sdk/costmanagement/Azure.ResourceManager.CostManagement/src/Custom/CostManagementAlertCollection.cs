// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.CostManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CostManagement
{
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    public partial class CostManagementAlertCollection
    {
        /// <summary> Lists the alerts for scope defined. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<CostManagementAlertResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<CostManagementAlertResource> FirstPage(int? pageSizeHint)
            {
                using DiagnosticScope scope = _alertsClientDiagnostics.CreateScope("CostManagementAlertCollection.GetAll");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _alertsRestClient.CreateGetAllRequest(Id, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    var data = CostManagementAlertsResult.FromResponse(result);
                    var resources = data.Value.Select(d => new CostManagementAlertResource(Client, d)).ToList();
                    return Page<CostManagementAlertResource>.FromValues(resources, null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPage, null);
        }

        /// <summary> Lists the alerts for scope defined. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<CostManagementAlertResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CostManagementAlertResource>> FirstPageAsync(int? pageSizeHint)
            {
                using DiagnosticScope scope = _alertsClientDiagnostics.CreateScope("CostManagementAlertCollection.GetAll");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _alertsRestClient.CreateGetAllRequest(Id, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    var data = CostManagementAlertsResult.FromResponse(result);
                    var resources = data.Value.Select(d => new CostManagementAlertResource(Client, d)).ToList();
                    return Page<CostManagementAlertResource>.FromValues(resources, null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageAsync, null);
        }
    }
}
