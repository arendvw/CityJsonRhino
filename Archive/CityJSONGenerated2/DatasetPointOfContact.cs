using System;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class DatasetPointOfContact
    {
        [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("contactName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactName { get; set; }

        [JsonProperty("emailAddress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }

        [JsonProperty("phone", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("contactType", Required = Required.Always)]
        public ContactType ContactType { get; set; }

        [JsonProperty("organization", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Organization { get; set; }

        /// <summary>
        /// from ISO 19115 codelist
        /// </summary>
        [JsonProperty("role", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Role? Role { get; set; }

        [JsonProperty("website", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri Website { get; set; }
    }
}