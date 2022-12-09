using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class LocationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocationType) || t == typeof(LocationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "MultiPoint")
            {
                return LocationType.MultiPoint;
            }
            throw new Exception("Cannot unmarshal type LocationType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LocationType)untypedValue;
            if (value == LocationType.MultiPoint)
            {
                serializer.Serialize(writer, "MultiPoint");
                return;
            }
            throw new Exception("Cannot marshal type LocationType");
        }

        public static readonly LocationTypeConverter Singleton = new LocationTypeConverter();
    }
}