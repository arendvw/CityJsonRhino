using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class TemplateTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TemplateType) || t == typeof(TemplateType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CompositeSolid":
                    return TemplateType.CompositeSolid;
                case "CompositeSurface":
                    return TemplateType.CompositeSurface;
                case "MultiLineString":
                    return TemplateType.MultiLineString;
                case "MultiPoint":
                    return TemplateType.MultiPoint;
                case "MultiSolid":
                    return TemplateType.MultiSolid;
                case "MultiSurface":
                    return TemplateType.MultiSurface;
                case "Solid":
                    return TemplateType.Solid;
            }
            throw new Exception("Cannot unmarshal type TemplateType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TemplateType)untypedValue;
            switch (value)
            {
                case TemplateType.CompositeSolid:
                    serializer.Serialize(writer, "CompositeSolid");
                    return;
                case TemplateType.CompositeSurface:
                    serializer.Serialize(writer, "CompositeSurface");
                    return;
                case TemplateType.MultiLineString:
                    serializer.Serialize(writer, "MultiLineString");
                    return;
                case TemplateType.MultiPoint:
                    serializer.Serialize(writer, "MultiPoint");
                    return;
                case TemplateType.MultiSolid:
                    serializer.Serialize(writer, "MultiSolid");
                    return;
                case TemplateType.MultiSurface:
                    serializer.Serialize(writer, "MultiSurface");
                    return;
                case TemplateType.Solid:
                    serializer.Serialize(writer, "Solid");
                    return;
            }
            throw new Exception("Cannot marshal type TemplateType");
        }

        public static readonly TemplateTypeConverter Singleton = new TemplateTypeConverter();
    }
}