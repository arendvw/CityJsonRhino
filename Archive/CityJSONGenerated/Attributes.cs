using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Attributes
    {
        [JsonProperty("class", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Class { get; set; }

        [JsonProperty("creationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("function", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Function { get; set; }

        [JsonProperty("terminationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? TerminationDate { get; set; }

        [JsonProperty("usage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Usage { get; set; }

        [JsonProperty("measuredHeight", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? MeasuredHeight { get; set; }

        [JsonProperty("roofType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string RoofType { get; set; }

        [JsonProperty("storeyHeightsAboveGround", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> StoreyHeightsAboveGround { get; set; }

        [JsonProperty("storeyHeightsBelowGround", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> StoreyHeightsBelowGround { get; set; }

        [JsonProperty("storeysAboveGround", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? StoreysAboveGround { get; set; }

        [JsonProperty("storeysBelowGround", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? StoreysBelowGround { get; set; }

        [JsonProperty("yearOfConstruction", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? YearOfConstruction { get; set; }

        [JsonProperty("yearOfDemolition", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? YearOfDemolition { get; set; }

        [JsonProperty("surfaceMaterial", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SurfaceMaterial { get; set; }

        [JsonProperty("crownDiameter", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? CrownDiameter { get; set; }

        [JsonProperty("height", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Height { get; set; }

        [JsonProperty("species", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Species { get; set; }

        [JsonProperty("trunkDiameter", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TrunkDiameter { get; set; }

        [JsonProperty("averageHeight", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? AverageHeight { get; set; }

        [JsonProperty("isMovable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsMovable { get; set; }
    }
}