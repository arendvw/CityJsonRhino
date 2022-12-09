using Newtonsoft.Json;

namespace CityJSON
{
    public partial class PurpleSurface
    {
        [JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}