using System;
using System.Collections.Generic;
using System.Text;

namespace CityJSON
{
    class CityObject
    {
        /// <summary>
        /// the IDs of the CityObjects members of that group
        /// </summary>
        [JsonProperty("members", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Members { get; set; }
    }
}
