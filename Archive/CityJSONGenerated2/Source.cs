using System;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Source
    {
        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("scope", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("sourceCitation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri SourceCitation { get; set; }

        [JsonProperty("sourceMetadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri SourceMetadata { get; set; }

        [JsonProperty("sourceReferenceSystem", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceReferenceSystem { get; set; }

        [JsonProperty("sourceSpatialResolution", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceSpatialResolution { get; set; }
    }
}