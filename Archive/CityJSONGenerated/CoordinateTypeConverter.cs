using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class CoordinateTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CoordinateType) || t == typeof(CoordinateType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "CityJSON")
            {
                return CoordinateType.CityJson;
            }
            throw new Exception("Cannot unmarshal type CoordinateType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CoordinateType)untypedValue;
            if (value == CoordinateType.CityJson)
            {
                serializer.Serialize(writer, "CityJSON");
                return;
            }
            throw new Exception("Cannot marshal type CoordinateType");
        }

        public static readonly CoordinateTypeConverter Singleton = new CoordinateTypeConverter();
    }
}