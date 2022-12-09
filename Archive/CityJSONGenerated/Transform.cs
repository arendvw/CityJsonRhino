using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Transform
    {
        [JsonProperty("scale", Required = Required.Always)]
        public List<double> Scale { get; set; }

        [JsonProperty("translate", Required = Required.Always)]
        public List<double> Translate { get; set; }
    }
}