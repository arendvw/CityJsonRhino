using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class FluffyBoundaryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FluffyBoundary) || t == typeof(FluffyBoundary?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new FluffyBoundary { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<PurpleBoundary>>(reader);
                    return new FluffyBoundary { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type FluffyBoundary");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (FluffyBoundary)untypedValue;
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
            throw new Exception("Cannot marshal type FluffyBoundary");
        }

        public static readonly FluffyBoundaryConverter Singleton = new FluffyBoundaryConverter();
    }
}