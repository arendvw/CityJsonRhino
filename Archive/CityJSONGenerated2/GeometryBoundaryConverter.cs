using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class GeometryBoundaryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GeometryBoundary) || t == typeof(GeometryBoundary?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new GeometryBoundary { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<TentacledBoundary>>(reader);
                    return new GeometryBoundary { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type GeometryBoundary");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (GeometryBoundary)untypedValue;
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
            throw new Exception("Cannot marshal type GeometryBoundary");
        }

        public static readonly GeometryBoundaryConverter Singleton = new GeometryBoundaryConverter();
    }
}