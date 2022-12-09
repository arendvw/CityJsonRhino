using Newtonsoft.Json;

namespace CityJSON
{
    public partial class CityfeatureMetadatum
    {
        [JsonProperty("aggregateFeatureCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? AggregateFeatureCount { get; set; }

        [JsonProperty("presentLoDs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public CityfeatureMetadatumPresentLoDs PresentLoDs { get; set; }

        [JsonProperty("uniqueFeatureCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? UniqueFeatureCount { get; set; }
    }
}