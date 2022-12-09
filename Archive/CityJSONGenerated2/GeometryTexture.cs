using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class GeometryTexture
    {
        [JsonProperty("values", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<List<List<MaterialValue>>> Values { get; set; }
    }
}