using System.Collections.Generic;
using CityJSON.Converters;
using CityJSON.Geometry.Semantics;
using Newtonsoft.Json;

namespace CityJSON.Geometry
{
    /// <summary>
    /// Solid geometry has metadata per face.
    /// </summary>
    public class SolidGeometry : Geometry
    {
        [JsonProperty("boundaries", Required = Required.Always)]
        public SolidBoundary Boundaries { get; set; }

        [JsonProperty("semantics", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public SemanticsList<List<List<int?>>> Semantics { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(GeometryTypeConverter))]
        public override GeometryType Type => GeometryType.Solid;
    }
}