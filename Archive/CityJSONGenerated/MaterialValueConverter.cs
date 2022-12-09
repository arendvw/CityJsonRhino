using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class MaterialValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MaterialValue) || t == typeof(MaterialValue?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new MaterialValue { };
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new MaterialValue { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<ValueValue>>(reader);
                    return new MaterialValue { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type MaterialValue");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (MaterialValue)untypedValue;
            if (value.IsNull)
            {
                serializer.Serialize(writer, null);
                return;
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.AnythingArray != null)
            {
                serializer.Serialize(writer, value.AnythingArray);
                return;
            }
            throw new Exception("Cannot marshal type MaterialValue");
        }

        public static readonly MaterialValueConverter Singleton = new MaterialValueConverter();
    }
}