using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON.Geometry.Semantics
{
    public class SemanticsList<T>
    {
        /// <summary>
        /// List of surface id's within the geometry
        /// </summary>
        [JsonProperty("surfaces", Required = Required.Always)]
        public List<Semantics> Surfaces { get; set; }

        [JsonProperty("values", Required = Required.AllowNull)]
        public T Values { get; set; }
    }
}