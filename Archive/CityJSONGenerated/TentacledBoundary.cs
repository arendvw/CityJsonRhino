using System.Collections.Generic;

namespace CityJSON
{
    public partial struct TentacledBoundary
    {
        public List<FluffyBoundary> AnythingArray;
        public long? Integer;

        public static implicit operator TentacledBoundary(List<FluffyBoundary> AnythingArray) => new TentacledBoundary { AnythingArray = AnythingArray };
        public static implicit operator TentacledBoundary(long Integer) => new TentacledBoundary { Integer = Integer };
    }
}