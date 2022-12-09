using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class MinMaxValueCheckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(double) || t == typeof(double?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<double>(reader);
            if (value >= 0 && value <= 3.5)
            {
                return value;
            }
            throw new Exception("Cannot unmarshal type double");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (double)untypedValue;
            if (value >= 0 && value <= 3.5)
            {
                serializer.Serialize(writer, value);
                return;
            }
            throw new Exception("Cannot marshal type double");
        }

        public static readonly MinMaxValueCheckConverter Singleton = new MinMaxValueCheckConverter();
    }
}