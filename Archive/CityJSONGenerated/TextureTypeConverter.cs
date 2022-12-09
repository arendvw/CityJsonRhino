using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class TextureTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TextureType) || t == typeof(TextureType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "JPG":
                    return TextureType.Jpg;
                case "PNG":
                    return TextureType.Png;
            }
            throw new Exception("Cannot unmarshal type TextureType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TextureType)untypedValue;
            switch (value)
            {
                case TextureType.Jpg:
                    serializer.Serialize(writer, "JPG");
                    return;
                case TextureType.Png:
                    serializer.Serialize(writer, "PNG");
                    return;
            }
            throw new Exception("Cannot marshal type TextureType");
        }

        public static readonly TextureTypeConverter Singleton = new TextureTypeConverter();
    }
}