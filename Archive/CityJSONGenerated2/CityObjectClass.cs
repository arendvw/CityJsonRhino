using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class CityObjectClass
    {
        [JsonProperty("attributes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Attributes { get; set; }

        /// <summary>
        /// the IDs of children
        /// </summary>
        [JsonProperty("children", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Children { get; set; }

        [JsonProperty("geographicalExtent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> GeographicalExtent { get; set; }

        /// <summary>
        /// the IDs of the parents
        /// </summary>
        [JsonProperty("parents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Parents { get; set; }

        [JsonProperty("geometry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Geometry> Geometry { get; set; }

        /// <summary>
        /// the IDs of the CityObjects members of that group
        /// </summary>
        [JsonProperty("members", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Members { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }
    }
}