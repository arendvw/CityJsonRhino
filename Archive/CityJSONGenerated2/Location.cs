using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Location
    {
        [JsonProperty("boundaries", Required = Required.Always)]
        public List<long> Boundaries { get; set; }

        [JsonProperty("lod", Required = Required.Always)]
        [JsonConverter(typeof(MinMaxValueCheckConverter))]
        public double Lod { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public LocationType Type { get; set; }
    }
}