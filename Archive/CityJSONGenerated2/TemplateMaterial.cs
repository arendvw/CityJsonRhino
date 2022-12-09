using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class TemplateMaterial
    {
        [JsonProperty("value", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }

        [JsonProperty("values")]
        public List<object> Values { get; set; }
    }
}