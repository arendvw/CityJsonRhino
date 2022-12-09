using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class TextureElement
    {
        [JsonProperty("borderColor", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> BorderColor { get; set; }

        [JsonProperty("image", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("textureType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TextureTypeEnum? TextureType { get; set; }

        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TextureType? Type { get; set; }

        [JsonProperty("wrapMode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public WrapMode? WrapMode { get; set; }
    }
}