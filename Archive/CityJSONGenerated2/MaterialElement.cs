using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJson
{
    public class MaterialElement
    {
        [JsonProperty("ambientIntensity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? AmbientIntensity { get; set; }

        [JsonProperty("diffuseColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> DiffuseColor { get; set; }

        [JsonProperty("emissiveColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> EmissiveColor { get; set; }

        [JsonProperty("isSmooth", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSmooth { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("shininess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Shininess { get; set; }

        [JsonProperty("specularColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> SpecularColor { get; set; }

        [JsonProperty("transparency", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Transparency { get; set; }
    }
}