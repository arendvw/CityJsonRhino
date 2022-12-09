using System;
using GH_IO.Types;

namespace CityJsonRhino.Attributes
{
    public class GhField : Attribute
    {
        public string FieldName { get; set; }
        public GH_Types Type { get; set; }
    }
}
