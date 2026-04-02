// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.CostManagement;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CostManagement.Models
{
    [CodeGenSuppress("ExportRun", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(ExportRunExecutionType?), typeof(ExportRunExecutionStatus?), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(CommonExportProperties), typeof(ExportRunErrorDetails), typeof(ETag?))]
    [CodeGenSuppress("ForecastResult", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(IEnumerable<ForecastColumn>), typeof(IEnumerable<IList<BinaryData>>), typeof(AzureLocation?), typeof(string), typeof(ETag?), typeof(IReadOnlyDictionary<string, string>))]
    [CodeGenSuppress("CostManagementDimension", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(bool?), typeof(bool?), typeof(IEnumerable<string>), typeof(int?), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(AzureLocation?), typeof(string), typeof(ETag?), typeof(IReadOnlyDictionary<string, string>))]
    [CodeGenSuppress("QueryResult", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(IEnumerable<QueryColumn>), typeof(IEnumerable<IList<BinaryData>>), typeof(AzureLocation?), typeof(string), typeof(ETag?), typeof(IReadOnlyDictionary<string, string>))]
    public static partial class ArmCostManagementModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ExportRun"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ExportRun ExportRun(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ExportRunExecutionType? executionType, ExportRunExecutionStatus? status, string submittedBy, DateTimeOffset? submittedOn, DateTimeOffset? processingStartOn, DateTimeOffset? processingEndOn, string fileName, CommonExportProperties runSettings, ExportRunErrorDetails error, ETag? eTag)
        {
            return ExportRun(
                id: id,
                name: name,
                etag: eTag,
                executionType: executionType,
                status: status,
                submittedBy: submittedBy,
                submittedOn: submittedOn,
                processingStartOn: processingStartOn,
                processingEndOn: processingEndOn,
                fileName: fileName,
                runSettings: runSettings,
                error: error);
        }
    }
}
