using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class TemplateTexture
    {
        [JsonProperty("values", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<List<List<MaterialValue>>> Values { get; set; }
    }
}