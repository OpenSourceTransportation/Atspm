﻿#region license
// Copyright 2025 Utah Departement of Transportation
// for Application - Utah.Udot.Atspm.Business.Aggregation/AggregationOptions.cs
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

using Utah.Udot.Atspm.Business.Aggregation.FilterExtensions;
using Utah.Udot.Atspm.Business.Bins;
using Utah.Udot.Atspm.Data.Enums;

namespace Utah.Udot.Atspm.Business.Aggregation
{
    public class AggregationOptions
    {
        public List<string> LocationIdentifiers { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public AggregationType AggregationType { get; set; }
        public DetectionTypes? DetectionType { get; set; }
        public int DataType { get; set; }
        public TimeOptions TimeOptions { get; set; }
        public AggregationCalculationType SelectedAggregationType { get; set; }
        public XAxisType SelectedXAxisType { get; set; }
        public SeriesType SelectedSeries { get; set; }
        public List<FilterSignal> Locations { get; set; } = new List<FilterSignal>();
        public List<FilterDirection> FilterDirections { get; set; }
        public List<FilterMovement> FilterMovements { get; set; }
    }
}