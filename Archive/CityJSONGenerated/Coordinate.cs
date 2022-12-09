using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public class Coordinate
    {
        [JsonProperty("appearance", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Appearance Appearance { get; set; }

        [JsonProperty("CityObjects", Required = Required.Always)]
        public Dictionary<string, CityObjectValue> CityObjects { get; set; }

        [JsonProperty("extensions", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Extension> Extensions { get; set; }

        [JsonProperty("geometry-templates", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public GeometryTemplates GeometryTemplates { get; set; }

        [JsonProperty("metadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Metadata Metadata { get; set; }

        [JsonProperty("transform", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Transform Transform { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public CoordinateType Type { get; set; }

        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }

        [JsonProperty("vertices", Required = Required.Always)]
        public List<List<double>> Vertices { get; set; }

        public static Coordinate FromJson(string json) => JsonConvert.DeserializeObject<Coordinate>(json, Converter.Settings);
    }
}