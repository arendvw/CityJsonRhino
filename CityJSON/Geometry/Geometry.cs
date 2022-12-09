using CityJSON.Converters;
using Newtonsoft.Json;

namespace CityJSON.Geometry
{
    [JsonConverter(typeof(GeometryConverter))]
    public abstract class Geometry
    {
        [JsonProperty("lod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Lod { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(GeometryTypeConverter))]
        public abstract GeometryType Type { get; }
    }
}