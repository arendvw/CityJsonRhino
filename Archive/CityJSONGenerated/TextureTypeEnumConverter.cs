using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class TextureTypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TextureTypeEnum) || t == typeof(TextureTypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "specific":
                    return TextureTypeEnum.Specific;
                case "typical":
                    return TextureTypeEnum.Typical;
                case "unknown":
                    return TextureTypeEnum.Unknown;
            }
            throw new Exception("Cannot unmarshal type TextureTypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TextureTypeEnum)untypedValue;
            switch (value)
            {
                case TextureTypeEnum.Specific:
                    serializer.Serialize(writer, "specific");
                    return;
                case TextureTypeEnum.Typical:
                    serializer.Serialize(writer, "typical");
                    return;
                case TextureTypeEnum.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type TextureTypeEnum");
        }

        public static readonly TextureTypeEnumConverter Singleton = new TextureTypeEnumConverter();
    }
}