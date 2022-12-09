using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CityJSON.Converters
{
    public class VertexConverter : JsonConverter
    {
        static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings
        {
            ContractResolver = new GeometryClassConverter()
        };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Vertex));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray geometry = null;
            try
            {
                geometry = JArray.Load(reader);
                var vertices = geometry.Values<double>().ToList();
                if (vertices.Count == 3)
                {
                    return new Vertex
                    {
                        X = vertices[0],
                        Y = vertices[1],
                        Z = vertices[2]
                    };
                }

                throw new ArgumentException("Invalid vertex count");
            }
            catch (JsonSerializationException jse)
            {
                // {jse.Path} line {jse.LineNumber} {jse.LinePosition}
                throw new JsonSerializationException($"{jse.Message} {reader.Path}\n{geometry?.ToString()},", jse);
            }
        }

        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var vertex = (Vertex)value;
            serializer.Serialize(writer, new[] { vertex.X, vertex.Y, vertex.Z });
        }
    }
}
