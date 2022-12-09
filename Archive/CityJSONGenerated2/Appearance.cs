using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJson
{
    public class Appearance
    {
        [JsonProperty("default-theme-material", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultThemeMaterial { get; set; }

        [JsonProperty("default-theme-texture", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultThemeTexture { get; set; }

        [JsonProperty("materials", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<MaterialElement> Materials { get; set; }

        [JsonProperty("textures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<TextureElement> Textures { get; set; }

        [JsonProperty("vertices-texture", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<List<double>> VerticesTexture { get; set; }
    }


    public enum TextureTypeEnum { Specific, Typical, Unknown };
    public enum TextureType { Jpg, Png };
    public enum WrapMode { Border, Clamp, Mirror, None, Wrap };
}