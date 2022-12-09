using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class PurpleBoundaryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PurpleBoundary) || t == typeof(PurpleBoundary?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new PurpleBoundary { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<long>>(reader);
                    return new PurpleBoundary { IntegerArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type PurpleBoundary");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (PurpleBoundary)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.IntegerArray != null)
            {
                serializer.Serialize(writer, value.IntegerArray);
                return;
            }
            throw new Exception("Cannot marshal type PurpleBoundary");
        }

        public static readonly PurpleBoundaryConverter Singleton = new PurpleBoundaryConverter();
    }
}