using System.Collections.Generic;

namespace CityJSON
{
    public partial struct GeometryBoundary
    {
        public List<TentacledBoundary> AnythingArray;
        public long? Integer;

        public static implicit operator GeometryBoundary(List<TentacledBoundary> AnythingArray) => new GeometryBoundary { AnythingArray = AnythingArray };
        public static implicit operator GeometryBoundary(long Integer) => new GeometryBoundary { Integer = Integer };
    }
}