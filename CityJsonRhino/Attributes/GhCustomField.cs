using System;

namespace CityJsonRhino.Attributes
{
    public class GhCustomField : Attribute
    {
        public string FieldName { get; set; }
        public Type Serializer { get; set; }
    }
}