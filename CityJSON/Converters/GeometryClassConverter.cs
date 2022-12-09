using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CityJSON.Converters
{
    public class GeometryClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Geometry.Geometry).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }
}