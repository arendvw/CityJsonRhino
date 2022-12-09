using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class WrapModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WrapMode) || t == typeof(WrapMode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "border":
                    return WrapMode.Border;
                case "clamp":
                    return WrapMode.Clamp;
                case "mirror":
                    return WrapMode.Mirror;
                case "none":
                    return WrapMode.None;
                case "wrap":
                    return WrapMode.Wrap;
            }
            throw new Exception("Cannot unmarshal type WrapMode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WrapMode)untypedValue;
            switch (value)
            {
                case WrapMode.Border:
                    serializer.Serialize(writer, "border");
                    return;
                case WrapMode.Clamp:
                    serializer.Serialize(writer, "clamp");
                    return;
                case WrapMode.Mirror:
                    serializer.Serialize(writer, "mirror");
                    return;
                case WrapMode.None:
                    serializer.Serialize(writer, "none");
                    return;
                case WrapMode.Wrap:
                    serializer.Serialize(writer, "wrap");
                    return;
            }
            throw new Exception("Cannot marshal type WrapMode");
        }

        public static readonly WrapModeConverter Singleton = new WrapModeConverter();
    }
}