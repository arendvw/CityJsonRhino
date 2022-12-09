using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class MaterialsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Materials) || t == typeof(Materials?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "absent":
                    return Materials.Absent;
                case "present":
                    return Materials.Present;
            }
            throw new Exception("Cannot unmarshal type Materials");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Materials)untypedValue;
            switch (value)
            {
                case Materials.Absent:
                    serializer.Serialize(writer, "absent");
                    return;
                case Materials.Present:
                    serializer.Serialize(writer, "present");
                    return;
            }
            throw new Exception("Cannot marshal type Materials");
        }

        public static readonly MaterialsConverter Singleton = new MaterialsConverter();
    }
}