using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJson
{
    class CityJSON
    {
        [JsonProperty("appearance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Appearance Appearance { get; set; }

        [JsonProperty("CityObjects", Required = Required.Always)]
        public Dictionary<string, CityObjectValue> CityObjects { get; set; }

        /// <summary>
        /// Scale and translation of the model in the real world
        /// </summary>
        [JsonProperty("transform", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Transform Transform { get; set; }

        /// <summary>
        /// List of points
        /// </summary>
        [JsonProperty("vertices", Required = Required.Always)]
        public List<List<double>> Vertices { get; set; }

        /// <summary>
        /// This is always "CityJSON"
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public CoordinateType Type { get; set; }

        /// <summary>
        /// Version of json document
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }

        /// <summary>
        /// currently not supported
        /// </summary>
        [JsonProperty("metadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata => null;

        /// <summary>
        /// currently not supported
        /// </summary>
        [JsonProperty("geometry-templates", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public object GeometryTemplates => null;

        /// <summary>
        /// currently not supported
        /// </summary>
        [JsonProperty("extensions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Extensions => null;
    }
}
