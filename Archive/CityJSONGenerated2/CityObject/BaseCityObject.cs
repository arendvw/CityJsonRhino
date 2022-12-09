using System;
using System.Collections.Generic;
using System.Text;
using CityJsonAvw.Geometry;
using Newtonsoft.Json;

namespace CityJsonAvw.CityObject
{
    public class BaseCityObject
    {
        
        [JsonProperty("attributes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Attributes { get; set; }
        public AbstractGeometry<AbstractGeometry>> Geometry { get; set; }

        public List<string> Parents { get; set; }
        /// <summary>
        /// the IDs of children
        /// </summary>
        [JsonProperty("children", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Children { get; set; }

        /// <summary>
        /// Property is not supported
        /// </summary>
        [JsonProperty("geographicalExtent", Required = Required.DisallowNull,
            NullValueHandling = NullValueHandling.Ignore)]
        public List<double> GeographicalExtent => null;
    }
}
