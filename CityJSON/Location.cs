using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Location
    {
        /// <summary>
        /// List of addresses associated with this location
        /// </summary>
        [JsonProperty("boundaries", Required = Required.Always)]
        public List<int> Boundaries { get; set; }

        [JsonProperty("lod", Required = Required.Always)]
        public double Lod { get; set; }

        /// <summary>
        /// Always multipoints
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }
    }
}