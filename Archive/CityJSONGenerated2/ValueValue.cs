using System.Collections.Generic;

namespace CityJSON
{
    public partial struct ValueValue
    {
        public long? Integer;
        public List<long?> UnionArray;

        public static implicit operator ValueValue(long Integer) => new ValueValue { Integer = Integer };
        public static implicit operator ValueValue(List<long?> UnionArray) => new ValueValue { UnionArray = UnionArray };
        public bool IsNull => UnionArray == null && Integer == null;
    }
}