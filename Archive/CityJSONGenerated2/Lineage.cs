using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Lineage
    {
        [JsonProperty("additionalDocumentation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri AdditionalDocumentation { get; set; }

        [JsonProperty("featureIDs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FeatureIDs { get; set; }

        [JsonProperty("processStep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessStep ProcessStep { get; set; }

        [JsonProperty("scope", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty("source", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Source> Source { get; set; }

        [JsonProperty("statement", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Statement { get; set; }

        [JsonProperty("thematicModels", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ThematicModels { get; set; }
    }
}