﻿#region license
// Copyright 2025 Utah Departement of Transportation
// for ConfigApi - Utah.Udot.Atspm.ConfigApi.Configuration/RouteDistanceOdataConfiguration.cs
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using Asp.Versioning;
using Asp.Versioning.OData;
using Microsoft.OData.ModelBuilder;
using Utah.Udot.Atspm.Data.Models;

namespace Utah.Udot.Atspm.ConfigApi.Configuration
{
    /// <summary>
    /// Route distance oData configuration
    /// </summary>
    public class RouteDistanceOdataConfiguration : IModelConfiguration
    {
        ///<inheritdoc/>
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix)
        {
            var model = builder.EntitySet<RouteDistance>("RouteDistance").EntityType;
            model.Page(default, default);

            switch (apiVersion.MajorVersion)
            {
                case 1:
                    {
                        model.Property(p => p.Distance).IsRequired();

                        var c = model.Collection.Function("GetRouteDistanceByLocationIdentifiers");
                        c.Parameter<string>("locationA");
                        c.Parameter<string>("locationB");
                        c.ReturnsFromEntitySet<RouteDistance>("RouteDistance");

                        break;
                    }
            }
        }
    }
}
