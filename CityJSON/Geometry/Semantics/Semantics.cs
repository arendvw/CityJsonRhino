using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CityJSON.Geometry.Semantics
{
    public class Semantics
    {
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("parent", Required = Required.DisallowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Parent { get; set; }

        [JsonProperty("children", Required = Required.DisallowNull, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<int> Children { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JToken> Attributes { get; set; }
    }
}