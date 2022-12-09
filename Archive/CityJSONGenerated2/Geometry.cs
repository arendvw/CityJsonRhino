using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Geometry
    {
        [JsonProperty("boundaries", Required = Required.Always)]
        public List<GeometryBoundary> Boundaries { get; set; }

        [JsonProperty("lod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(MinMaxValueCheckConverter))]
        public double? Lod { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public GeometryType Type { get; set; }

        [JsonProperty("material", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, GeometryMaterial> Material { get; set; }

        [JsonProperty("semantics", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public GeometrySemantics Semantics { get; set; }

        [JsonProperty("texture", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, GeometryTexture> Texture { get; set; }

        [JsonProperty("template", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Template { get; set; }

        [JsonProperty("transformationMatrix", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> TransformationMatrix { get; set; }
    }
}