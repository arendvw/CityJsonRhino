using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class ValueValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ValueValue) || t == typeof(ValueValue?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new ValueValue { };
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new ValueValue { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<long?>>(reader);
                    return new ValueValue { UnionArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type ValueValue");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ValueValue)untypedValue;
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
            if (value.UnionArray != null)
            {
                serializer.Serialize(writer, value.UnionArray);
                return;
            }
            throw new Exception("Cannot marshal type ValueValue");
        }

        public static readonly ValueValueConverter Singleton = new ValueValueConverter();
    }
}