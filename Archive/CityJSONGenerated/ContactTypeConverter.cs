using System;
using Newtonsoft.Json;

namespace CityJSON
{
    public enum ContactType { Individual, Organization };

    internal class ContactTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ContactType) || t == typeof(ContactType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "individual":
                    return ContactType.Individual;
                case "organization":
                    return ContactType.Organization;
            }
            throw new Exception("Cannot unmarshal type ContactType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ContactType)untypedValue;
            switch (value)
            {
                case ContactType.Individual:
                    serializer.Serialize(writer, "individual");
                    return;
                case ContactType.Organization:
                    serializer.Serialize(writer, "organization");
                    return;
            }
            throw new Exception("Cannot marshal type ContactType");
        }

        public static readonly ContactTypeConverter Singleton = new ContactTypeConverter();
    }
}