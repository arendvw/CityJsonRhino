using System.Collections.Generic;

namespace CityJSON
{
    public partial struct PurpleBoundary
    {
        public long? Integer;
        public List<long> IntegerArray;

        public static implicit operator PurpleBoundary(long Integer) => new PurpleBoundary { Integer = Integer };
        public static implicit operator PurpleBoundary(List<long> IntegerArray) => new PurpleBoundary { IntegerArray = IntegerArray };
    }
}