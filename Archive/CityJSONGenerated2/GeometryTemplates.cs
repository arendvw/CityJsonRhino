using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class GeometryTemplates
    {
        [JsonProperty("templates", Required = Required.Always)]
        public List<Template> Templates { get; set; }

        [JsonProperty("vertices-templates", Required = Required.Always)]
        public List<List<double>> VerticesTemplates { get; set; }
    }
}