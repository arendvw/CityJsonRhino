using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class CityJsonObject
    {
        [JsonIgnore]
        public string Id { get; set; }

        [JsonProperty("attributes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Attributes { get; set; }

        /// <summary>
        /// the IDs of children
        /// </summary>
        [JsonProperty("children", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Children { get; set; }

        /// <summary>
        /// Xmin, Ymin, Zmin, Xmax, Ymax, Zmax
        /// </summary>
        [JsonProperty("geographicalExtent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> GeographicalExtent { get; set; }

        /// <summary>
        /// the IDs of the parents
        /// </summary>
        [JsonProperty("parents", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Parents { get; set; }

        [JsonProperty("geometry", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Geometry.Geometry> Geometry { get; set; }
        
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Address Address { get; set; }
    }
}