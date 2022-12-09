using System;
using CityJSON.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CityJSON.Converters
{
    public class GeometryConverter : JsonConverter
    {
        static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings
        {
            ContractResolver = new GeometryClassConverter()
        };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Geometry.Geometry));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject geometry = null;
                try
                {
                    geometry = JObject.Load(reader);
                    var type = geometry["type"]?.Value<string>()?.ToLowerInvariant();
                    switch (type)
                    {
                        case "solid":
                            return JsonConvert.DeserializeObject<SolidGeometry>(
                                geometry.ToString(),
                                SpecifiedSubclassConversion);
                        case "multisurface":
                            return JsonConvert.DeserializeObject<MultiSurfaceGeometry>(
                                geometry.ToString(),
                                SpecifiedSubclassConversion);
                        default:
                            throw new Exception();
                    }
                }
                catch (JsonSerializationException jse)
                {

                    //  {jse.Path} line {jse.LineNumber} {jse.LinePosition}\n
                    throw new JsonSerializationException(
                        $"{jse.Message} {geometry?.ToString()},",
                        jse);
                }
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }
    }
}
