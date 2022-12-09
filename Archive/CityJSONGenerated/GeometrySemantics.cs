﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class GeometrySemantics
    {
        [JsonProperty("surfaces", Required = Required.Always)]
        public List<PurpleSurface> Surfaces { get; set; }

        [JsonProperty("values", Required = Required.AllowNull)]
        public List<object> Values { get; set; }
    }
}