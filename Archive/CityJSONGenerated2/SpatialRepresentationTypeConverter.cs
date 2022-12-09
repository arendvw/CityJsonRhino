using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class SpatialRepresentationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SpatialRepresentationType) || t == typeof(SpatialRepresentationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "TIN":
                    return SpatialRepresentationType.Tin;
                case "grid":
                    return SpatialRepresentationType.Grid;
                case "stereoModel":
                    return SpatialRepresentationType.StereoModel;
                case "textTable":
                    return SpatialRepresentationType.TextTable;
                case "vector":
                    return SpatialRepresentationType.Vector;
                case "video":
                    return SpatialRepresentationType.Video;
            }
            throw new Exception("Cannot unmarshal type SpatialRepresentationType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SpatialRepresentationType)untypedValue;
            switch (value)
            {
                case SpatialRepresentationType.Tin:
                    serializer.Serialize(writer, "TIN");
                    return;
                case SpatialRepresentationType.Grid:
                    serializer.Serialize(writer, "grid");
                    return;
                case SpatialRepresentationType.StereoModel:
                    serializer.Serialize(writer, "stereoModel");
                    return;
                case SpatialRepresentationType.TextTable:
                    serializer.Serialize(writer, "textTable");
                    return;
                case SpatialRepresentationType.Vector:
                    serializer.Serialize(writer, "vector");
                    return;
                case SpatialRepresentationType.Video:
                    serializer.Serialize(writer, "video");
                    return;
            }
            throw new Exception("Cannot marshal type SpatialRepresentationType");
        }

        public static readonly SpatialRepresentationTypeConverter Singleton = new SpatialRepresentationTypeConverter();
    }
}