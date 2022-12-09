using System.Collections.Generic;

namespace CityJSON
{
    public partial struct MaterialValue
    {
        public List<ValueValue> AnythingArray;
        public long? Integer;

        public static implicit operator MaterialValue(List<ValueValue> AnythingArray) => new MaterialValue { AnythingArray = AnythingArray };
        public static implicit operator MaterialValue(long Integer) => new MaterialValue { Integer = Integer };
        public bool IsNull => AnythingArray == null && Integer == null;
    }
}