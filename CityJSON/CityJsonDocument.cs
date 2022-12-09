using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public class CityJsonDocument
    {
        /// <summary>
        /// currently not supported
        /// </summary>
        [JsonProperty("metadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Metadata Metadata { get; set; }

        [JsonProperty("CityObjects", Required = Required.Always)]
        public Dictionary<string, CityJsonObject> CityObjects { get; set; }

        /// <summary>
        /// Scale and translation of the model in the real world
        /// </summary>
        [JsonProperty("transform", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Transform Transform { get; set; }

        /// <summary>
        /// List of points
        /// </summary>
        [JsonProperty("vertices", Required = Required.Always)]
        public List<Vertex> Vertices { get; set; }

        /// <summary>
        /// This is always "CityJSON"
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; } = "CityJSON";

        /// <summary>
        /// Version of json document, this should always be 1.0
        /// </summary>
        [JsonProperty("version", Required = Required.Always)]
        public string Version { get; set; } = "1.0";

        public IEnumerable<Vertex> GetVertices(IEnumerable<int> ids)
        {
            foreach (var item in ids)
            {
                yield return Vertices[item];
            }
        }
        public Vertex GetVertex(int id)
        {
            return Vertices[id];
        }
    }
}
