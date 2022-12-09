using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class SecurityConstraintsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SecurityConstraints) || t == typeof(SecurityConstraints?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "confidential":
                    return SecurityConstraints.Confidential;
                case "forOfficialUseOnly":
                    return SecurityConstraints.ForOfficialUseOnly;
                case "limitedDistribution":
                    return SecurityConstraints.LimitedDistribution;
                case "protected":
                    return SecurityConstraints.Protected;
                case "restricted":
                    return SecurityConstraints.Restricted;
                case "secret":
                    return SecurityConstraints.Secret;
                case "sensitiveButUnclassified":
                    return SecurityConstraints.SensitiveButUnclassified;
                case "topSecret":
                    return SecurityConstraints.TopSecret;
                case "unclassified":
                    return SecurityConstraints.Unclassified;
            }
            throw new Exception("Cannot unmarshal type SecurityConstraints");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SecurityConstraints)untypedValue;
            switch (value)
            {
                case SecurityConstraints.Confidential:
                    serializer.Serialize(writer, "confidential");
                    return;
                case SecurityConstraints.ForOfficialUseOnly:
                    serializer.Serialize(writer, "forOfficialUseOnly");
                    return;
                case SecurityConstraints.LimitedDistribution:
                    serializer.Serialize(writer, "limitedDistribution");
                    return;
                case SecurityConstraints.Protected:
                    serializer.Serialize(writer, "protected");
                    return;
                case SecurityConstraints.Restricted:
                    serializer.Serialize(writer, "restricted");
                    return;
                case SecurityConstraints.Secret:
                    serializer.Serialize(writer, "secret");
                    return;
                case SecurityConstraints.SensitiveButUnclassified:
                    serializer.Serialize(writer, "sensitiveButUnclassified");
                    return;
                case SecurityConstraints.TopSecret:
                    serializer.Serialize(writer, "topSecret");
                    return;
                case SecurityConstraints.Unclassified:
                    serializer.Serialize(writer, "unclassified");
                    return;
            }
            throw new Exception("Cannot marshal type SecurityConstraints");
        }

        public static readonly SecurityConstraintsConverter Singleton = new SecurityConstraintsConverter();
    }
}