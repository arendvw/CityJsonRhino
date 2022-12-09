using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CityJSON
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CityObjectValueConverter.Singleton,
                LocationTypeConverter.Singleton,
                GeometryBoundaryConverter.Singleton,
                TentacledBoundaryConverter.Singleton,
                FluffyBoundaryConverter.Singleton,
                PurpleBoundaryConverter.Singleton,
                MaterialValueConverter.Singleton,
                ValueValueConverter.Singleton,
                GeometryTypeConverter.Singleton,
                TextureTypeEnumConverter.Singleton,
                TextureTypeConverter.Singleton,
                WrapModeConverter.Singleton,
                TemplateTypeConverter.Singleton,
                LegalConstraintsConverter.Singleton,
                SecurityConstraintsConverter.Singleton,
                ContactTypeConverter.Singleton,
                RoleConverter.Singleton,
                DatasetTopicCategoryConverter.Singleton,
                MaterialsConverter.Singleton,
                SpatialRepresentationTypeConverter.Singleton,
                CoordinateTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}