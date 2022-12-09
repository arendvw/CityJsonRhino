using System;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class TemporalExtent
    {
        [JsonProperty("endDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty("startDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartDate { get; set; }
    }
}