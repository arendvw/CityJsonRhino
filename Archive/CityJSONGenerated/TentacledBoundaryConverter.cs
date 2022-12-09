using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class TentacledBoundaryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TentacledBoundary) || t == typeof(TentacledBoundary?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new TentacledBoundary { Integer = integerValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<FluffyBoundary>>(reader);
                    return new TentacledBoundary { AnythingArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type TentacledBoundary");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (TentacledBoundary)untypedValue;
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
            throw new Exception("Cannot marshal type TentacledBoundary");
        }

        public static readonly TentacledBoundaryConverter Singleton = new TentacledBoundaryConverter();
    }
}