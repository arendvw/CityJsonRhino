using System;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class ProcessStep
    {
        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("processor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Processor Processor { get; set; }

        [JsonProperty("rationale", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Rationale { get; set; }

        [JsonProperty("reference", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri Reference { get; set; }

        [JsonProperty("scope", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("stepDateTime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StepDateTime { get; set; }
    }
}