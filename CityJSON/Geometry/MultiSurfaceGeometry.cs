using System.Collections.Generic;
using CityJSON.Geometry.Semantics;
using Newtonsoft.Json;

namespace CityJSON.Geometry
{
    public class MultiSurfaceGeometry : Geometry
    {
        [JsonProperty("boundaries", Required = Required.Always)]
        public MultiSurfaceBoundary Boundaries { get; set; }

        [JsonProperty("semantics", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public SemanticsList<List<int?>> Semantics { get; set; }

        public override GeometryType Type => GeometryType.MultiSurface;
    }
}