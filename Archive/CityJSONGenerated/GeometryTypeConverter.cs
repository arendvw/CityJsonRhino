using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class GeometryTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GeometryType) || t == typeof(GeometryType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CompositeSolid":
                    return GeometryType.CompositeSolid;
                case "CompositeSurface":
                    return GeometryType.CompositeSurface;
                case "GeometryInstance":
                    return GeometryType.GeometryInstance;
                case "MultiLineString":
                    return GeometryType.MultiLineString;
                case "MultiPoint":
                    return GeometryType.MultiPoint;
                case "MultiSolid":
                    return GeometryType.MultiSolid;
                case "MultiSurface":
                    return GeometryType.MultiSurface;
                case "Solid":
                    return GeometryType.Solid;
            }
            throw new Exception("Cannot unmarshal type GeometryType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GeometryType)untypedValue;
            switch (value)
            {
                case GeometryType.CompositeSolid:
                    serializer.Serialize(writer, "CompositeSolid");
                    return;
                case GeometryType.CompositeSurface:
                    serializer.Serialize(writer, "CompositeSurface");
                    return;
                case GeometryType.GeometryInstance:
                    serializer.Serialize(writer, "GeometryInstance");
                    return;
                case GeometryType.MultiLineString:
                    serializer.Serialize(writer, "MultiLineString");
                    return;
                case GeometryType.MultiPoint:
                    serializer.Serialize(writer, "MultiPoint");
                    return;
                case GeometryType.MultiSolid:
                    serializer.Serialize(writer, "MultiSolid");
                    return;
                case GeometryType.MultiSurface:
                    serializer.Serialize(writer, "MultiSurface");
                    return;
                case GeometryType.Solid:
                    serializer.Serialize(writer, "Solid");
                    return;
            }
            throw new Exception("Cannot marshal type GeometryType");
        }

        public static readonly GeometryTypeConverter Singleton = new GeometryTypeConverter();
    }
}