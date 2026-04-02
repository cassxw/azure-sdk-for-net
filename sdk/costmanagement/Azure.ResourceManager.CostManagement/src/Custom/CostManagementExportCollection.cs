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
    [CodeGenSuppress("GetAll", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(string), typeof(CancellationToken))]
    public partial class CostManagementExportCollection
    {
        /// <summary> Lists all exports at the given scope. </summary>
        /// <param name="expand"> May be used to expand the properties within an export. Currently only 'runHistory' is supported and will return information for the last run of each export. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<CostManagementExportResource> GetAll(string expand = default, CancellationToken cancellationToken = default)
        {
            Page<CostManagementExportResource> FirstPage(int? pageSizeHint)
            {
                using DiagnosticScope scope = _exportsClientDiagnostics.CreateScope("CostManagementExportCollection.GetAll");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _exportsRestClient.CreateGetAllRequest(Id, expand, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    var data = ExportListResult.FromResponse(result);
                    var resources = data.Value.Select(d => new CostManagementExportResource(Client, d)).ToList();
                    return Page<CostManagementExportResource>.FromValues(resources, null, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPage, null);
        }

        /// <summary> Lists all exports at the given scope. </summary>
        /// <param name="expand"> May be used to expand the properties within an export. Currently only 'runHistory' is supported and will return information for the last run of each export. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<CostManagementExportResource> GetAllAsync(string expand = default, CancellationToken cancellationToken = default)
        {
            async Task<Page<CostManagementExportResource>> FirstPageAsync(int? pageSizeHint)
            {
                using DiagnosticScope scope = _exportsClientDiagnostics.CreateScope("CostManagementExportCollection.GetAll");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _exportsRestClient.CreateGetAllRequest(Id, expand, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    var data = ExportListResult.FromResponse(result);
                    var resources = data.Value.Select(d => new CostManagementExportResource(Client, d)).ToList();
                    return Page<CostManagementExportResource>.FromValues(resources, null, result);
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
