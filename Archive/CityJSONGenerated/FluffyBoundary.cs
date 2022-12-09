using System.Collections.Generic;

namespace CityJSON
{
    public partial struct FluffyBoundary
    {
        public List<PurpleBoundary> AnythingArray;
        public long? Integer;

        public static implicit operator FluffyBoundary(List<PurpleBoundary> AnythingArray) => new FluffyBoundary { AnythingArray = AnythingArray };
        public static implicit operator FluffyBoundary(long Integer) => new FluffyBoundary { Integer = Integer };
    }
}