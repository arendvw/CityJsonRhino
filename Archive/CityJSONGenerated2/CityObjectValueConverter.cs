using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class CityObjectValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CityObjectValue) || t == typeof(CityObjectValue?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return new CityObjectValue { };
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new CityObjectValue { Integer = integerValue };
                case JsonToken.Float:
                    var doubleValue = serializer.Deserialize<double>(reader);
                    return new CityObjectValue { Double = doubleValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new CityObjectValue { Bool = boolValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new CityObjectValue { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<CityObjectClass>(reader);
                    return new CityObjectValue { CityObjectClass = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<object>>(reader);
                    return new CityObjectValue { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type CityObjectValue");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (CityObjectValue)untypedValue;
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
            if (value.Double != null)
            {
                serializer.Serialize(writer, value.Double.Value);
                return;
            }
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.AnythingArray != null)
            {
                serializer.Serialize(writer, value.AnythingArray);
                return;
            }
            if (value.CityObjectClass != null)
            {
                serializer.Serialize(writer, value.CityObjectClass);
                return;
            }
            throw new Exception("Cannot marshal type CityObjectValue");
        }

        public static readonly CityObjectValueConverter Singleton = new CityObjectValueConverter();
    }
}