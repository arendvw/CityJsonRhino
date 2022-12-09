﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var coordinate = Coordinate.FromJson(jsonString);

namespace CityJSON
{
    using Newtonsoft.Json;

    public partial class Address
    {
        [JsonProperty("CountryName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string CountryName { get; set; }

        [JsonProperty("LocalityName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LocalityName { get; set; }

        [JsonProperty("location", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Location Location { get; set; }

        [JsonProperty("PostalCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        [JsonProperty("ThoroughfareName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ThoroughfareName { get; set; }

        [JsonProperty("ThoroughfareNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ThoroughfareNumber { get; set; }
    }
}