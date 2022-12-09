using System;
using Newtonsoft.Json;

namespace CityJSON
{
    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "author":
                    return Role.Author;
                case "co-author":
                    return Role.CoAuthor;
                case "collaborator":
                    return Role.Collaborator;
                case "contributor":
                    return Role.Contributor;
                case "custodian":
                    return Role.Custodian;
                case "distributor":
                    return Role.Distributor;
                case "editor":
                    return Role.Editor;
                case "funder":
                    return Role.Funder;
                case "mediator":
                    return Role.Mediator;
                case "originator":
                    return Role.Originator;
                case "owner":
                    return Role.Owner;
                case "pointOfContact":
                    return Role.PointOfContact;
                case "principalInvestigator":
                    return Role.PrincipalInvestigator;
                case "processor":
                    return Role.Processor;
                case "publisher":
                    return Role.Publisher;
                case "resourceProvider":
                    return Role.ResourceProvider;
                case "rightsHolder":
                    return Role.RightsHolder;
                case "sponsor":
                    return Role.Sponsor;
                case "stakeholder":
                    return Role.Stakeholder;
                case "user":
                    return Role.User;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.Author:
                    serializer.Serialize(writer, "author");
                    return;
                case Role.CoAuthor:
                    serializer.Serialize(writer, "co-author");
                    return;
                case Role.Collaborator:
                    serializer.Serialize(writer, "collaborator");
                    return;
                case Role.Contributor:
                    serializer.Serialize(writer, "contributor");
                    return;
                case Role.Custodian:
                    serializer.Serialize(writer, "custodian");
                    return;
                case Role.Distributor:
                    serializer.Serialize(writer, "distributor");
                    return;
                case Role.Editor:
                    serializer.Serialize(writer, "editor");
                    return;
                case Role.Funder:
                    serializer.Serialize(writer, "funder");
                    return;
                case Role.Mediator:
                    serializer.Serialize(writer, "mediator");
                    return;
                case Role.Originator:
                    serializer.Serialize(writer, "originator");
                    return;
                case Role.Owner:
                    serializer.Serialize(writer, "owner");
                    return;
                case Role.PointOfContact:
                    serializer.Serialize(writer, "pointOfContact");
                    return;
                case Role.PrincipalInvestigator:
                    serializer.Serialize(writer, "principalInvestigator");
                    return;
                case Role.Processor:
                    serializer.Serialize(writer, "processor");
                    return;
                case Role.Publisher:
                    serializer.Serialize(writer, "publisher");
                    return;
                case Role.ResourceProvider:
                    serializer.Serialize(writer, "resourceProvider");
                    return;
                case Role.RightsHolder:
                    serializer.Serialize(writer, "rightsHolder");
                    return;
                case Role.Sponsor:
                    serializer.Serialize(writer, "sponsor");
                    return;
                case Role.Stakeholder:
                    serializer.Serialize(writer, "stakeholder");
                    return;
                case Role.User:
                    serializer.Serialize(writer, "user");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }
}