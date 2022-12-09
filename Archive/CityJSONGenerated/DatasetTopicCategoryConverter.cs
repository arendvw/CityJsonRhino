using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class DatasetTopicCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DatasetTopicCategory) || t == typeof(DatasetTopicCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "atmosphere":
                    return DatasetTopicCategory.Atmosphere;
                case "bioata":
                    return DatasetTopicCategory.Bioata;
                case "boundaries":
                    return DatasetTopicCategory.Boundaries;
                case "climatology":
                    return DatasetTopicCategory.Climatology;
                case "disaster":
                    return DatasetTopicCategory.Disaster;
                case "economy":
                    return DatasetTopicCategory.Economy;
                case "elevation":
                    return DatasetTopicCategory.Elevation;
                case "environment":
                    return DatasetTopicCategory.Environment;
                case "extraTerrestrial":
                    return DatasetTopicCategory.ExtraTerrestrial;
                case "farming":
                    return DatasetTopicCategory.Farming;
                case "geoscientificInformation":
                    return DatasetTopicCategory.GeoscientificInformation;
                case "health":
                    return DatasetTopicCategory.Health;
                case "imageryBaseMapsEarthCover":
                    return DatasetTopicCategory.ImageryBaseMapsEarthCover;
                case "inlandWaters":
                    return DatasetTopicCategory.InlandWaters;
                case "intelligenceMilitary":
                    return DatasetTopicCategory.IntelligenceMilitary;
                case "location":
                    return DatasetTopicCategory.Location;
                case "meteorology":
                    return DatasetTopicCategory.Meteorology;
                case "oceans":
                    return DatasetTopicCategory.Oceans;
                case "planningCadastre":
                    return DatasetTopicCategory.PlanningCadastre;
                case "society":
                    return DatasetTopicCategory.Society;
                case "structure":
                    return DatasetTopicCategory.Structure;
                case "transportation":
                    return DatasetTopicCategory.Transportation;
                case "utilitiesCommunication":
                    return DatasetTopicCategory.UtilitiesCommunication;
            }
            throw new Exception("Cannot unmarshal type DatasetTopicCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DatasetTopicCategory)untypedValue;
            switch (value)
            {
                case DatasetTopicCategory.Atmosphere:
                    serializer.Serialize(writer, "atmosphere");
                    return;
                case DatasetTopicCategory.Bioata:
                    serializer.Serialize(writer, "bioata");
                    return;
                case DatasetTopicCategory.Boundaries:
                    serializer.Serialize(writer, "boundaries");
                    return;
                case DatasetTopicCategory.Climatology:
                    serializer.Serialize(writer, "climatology");
                    return;
                case DatasetTopicCategory.Disaster:
                    serializer.Serialize(writer, "disaster");
                    return;
                case DatasetTopicCategory.Economy:
                    serializer.Serialize(writer, "economy");
                    return;
                case DatasetTopicCategory.Elevation:
                    serializer.Serialize(writer, "elevation");
                    return;
                case DatasetTopicCategory.Environment:
                    serializer.Serialize(writer, "environment");
                    return;
                case DatasetTopicCategory.ExtraTerrestrial:
                    serializer.Serialize(writer, "extraTerrestrial");
                    return;
                case DatasetTopicCategory.Farming:
                    serializer.Serialize(writer, "farming");
                    return;
                case DatasetTopicCategory.GeoscientificInformation:
                    serializer.Serialize(writer, "geoscientificInformation");
                    return;
                case DatasetTopicCategory.Health:
                    serializer.Serialize(writer, "health");
                    return;
                case DatasetTopicCategory.ImageryBaseMapsEarthCover:
                    serializer.Serialize(writer, "imageryBaseMapsEarthCover");
                    return;
                case DatasetTopicCategory.InlandWaters:
                    serializer.Serialize(writer, "inlandWaters");
                    return;
                case DatasetTopicCategory.IntelligenceMilitary:
                    serializer.Serialize(writer, "intelligenceMilitary");
                    return;
                case DatasetTopicCategory.Location:
                    serializer.Serialize(writer, "location");
                    return;
                case DatasetTopicCategory.Meteorology:
                    serializer.Serialize(writer, "meteorology");
                    return;
                case DatasetTopicCategory.Oceans:
                    serializer.Serialize(writer, "oceans");
                    return;
                case DatasetTopicCategory.PlanningCadastre:
                    serializer.Serialize(writer, "planningCadastre");
                    return;
                case DatasetTopicCategory.Society:
                    serializer.Serialize(writer, "society");
                    return;
                case DatasetTopicCategory.Structure:
                    serializer.Serialize(writer, "structure");
                    return;
                case DatasetTopicCategory.Transportation:
                    serializer.Serialize(writer, "transportation");
                    return;
                case DatasetTopicCategory.UtilitiesCommunication:
                    serializer.Serialize(writer, "utilitiesCommunication");
                    return;
            }
            throw new Exception("Cannot marshal type DatasetTopicCategory");
        }

        public static readonly DatasetTopicCategoryConverter Singleton = new DatasetTopicCategoryConverter();
    }
}