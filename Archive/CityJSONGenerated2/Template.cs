using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Template
    {
        [JsonProperty("boundaries", Required = Required.Always)]
        public List<GeometryBoundary> Boundaries { get; set; }

        [JsonProperty("lod", Required = Required.Always)]
        [JsonConverter(typeof(MinMaxValueCheckConverter))]
        public double Lod { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public TemplateType Type { get; set; }

        [JsonProperty("material", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, TemplateMaterial> Material { get; set; }

        [JsonProperty("semantics", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TemplateSemantics Semantics { get; set; }

        [JsonProperty("texture", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, TemplateTexture> Texture { get; set; }
    }
}