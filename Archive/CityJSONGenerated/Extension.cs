using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Extension
    {
        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; }
    }
}