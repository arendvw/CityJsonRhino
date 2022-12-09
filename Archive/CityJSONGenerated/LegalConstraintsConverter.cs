using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class LegalConstraintsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LegalConstraints) || t == typeof(LegalConstraints?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "confidential":
                    return LegalConstraints.Confidential;
                case "copyright":
                    return LegalConstraints.Copyright;
                case "in-confidence":
                    return LegalConstraints.InConfidence;
                case "intellectualPropertyRights":
                    return LegalConstraints.IntellectualPropertyRights;
                case "licence":
                    return LegalConstraints.Licence;
                case "licenseDistributor":
                    return LegalConstraints.LicenseDistributor;
                case "licenseEndUser":
                    return LegalConstraints.LicenseEndUser;
                case "licenseUnrestricted":
                    return LegalConstraints.LicenseUnrestricted;
                case "otherRestrictions":
                    return LegalConstraints.OtherRestrictions;
                case "patent":
                    return LegalConstraints.Patent;
                case "patentPending":
                    return LegalConstraints.PatentPending;
                case "private":
                    return LegalConstraints.Private;
                case "restricted":
                    return LegalConstraints.Restricted;
                case "sensitiveButUnclassified":
                    return LegalConstraints.SensitiveButUnclassified;
                case "statutory":
                    return LegalConstraints.Statutory;
                case "trademark":
                    return LegalConstraints.Trademark;
                case "unrestricted":
                    return LegalConstraints.Unrestricted;
            }
            throw new Exception("Cannot unmarshal type LegalConstraints");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LegalConstraints)untypedValue;
            switch (value)
            {
                case LegalConstraints.Confidential:
                    serializer.Serialize(writer, "confidential");
                    return;
                case LegalConstraints.Copyright:
                    serializer.Serialize(writer, "copyright");
                    return;
                case LegalConstraints.InConfidence:
                    serializer.Serialize(writer, "in-confidence");
                    return;
                case LegalConstraints.IntellectualPropertyRights:
                    serializer.Serialize(writer, "intellectualPropertyRights");
                    return;
                case LegalConstraints.Licence:
                    serializer.Serialize(writer, "licence");
                    return;
                case LegalConstraints.LicenseDistributor:
                    serializer.Serialize(writer, "licenseDistributor");
                    return;
                case LegalConstraints.LicenseEndUser:
                    serializer.Serialize(writer, "licenseEndUser");
                    return;
                case LegalConstraints.LicenseUnrestricted:
                    serializer.Serialize(writer, "licenseUnrestricted");
                    return;
                case LegalConstraints.OtherRestrictions:
                    serializer.Serialize(writer, "otherRestrictions");
                    return;
                case LegalConstraints.Patent:
                    serializer.Serialize(writer, "patent");
                    return;
                case LegalConstraints.PatentPending:
                    serializer.Serialize(writer, "patentPending");
                    return;
                case LegalConstraints.Private:
                    serializer.Serialize(writer, "private");
                    return;
                case LegalConstraints.Restricted:
                    serializer.Serialize(writer, "restricted");
                    return;
                case LegalConstraints.SensitiveButUnclassified:
                    serializer.Serialize(writer, "sensitiveButUnclassified");
                    return;
                case LegalConstraints.Statutory:
                    serializer.Serialize(writer, "statutory");
                    return;
                case LegalConstraints.Trademark:
                    serializer.Serialize(writer, "trademark");
                    return;
                case LegalConstraints.Unrestricted:
                    serializer.Serialize(writer, "unrestricted");
                    return;
            }
            throw new Exception("Cannot marshal type LegalConstraints");
        }

        public static readonly LegalConstraintsConverter Singleton = new LegalConstraintsConverter();
    }
}