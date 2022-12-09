using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Constraints
    {
        [JsonProperty("legalConstraints", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public LegalConstraints? LegalConstraints { get; set; }

        [JsonProperty("securityConstraints", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public SecurityConstraints? SecurityConstraints { get; set; }

        [JsonProperty("userNote", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string UserNote { get; set; }
    }
}