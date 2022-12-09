using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJson
{
    public class Transform
    {
        [JsonProperty("scale", Required = Required.Always)]
        public List<double> Scale { get; set; } = new List<double> { 1, 1, 1 };

        [JsonProperty("translate", Required = Required.Always)]
        public List<double> Translate { get; set; } = new List<double> { 0, 0, 0 };
    }
}