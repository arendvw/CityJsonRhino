using System.Collections.Generic;

namespace CityJSON
{
    public class MultiSolidBoundary : List<MultiSurfaceBoundary>
    {

    }

    public class SolidBoundary : List<MultiSurfaceBoundary>
    {

    }
    public class CompositeSurfaceBoundary : List<SurfaceBoundary>
    {
    }
    /// <summary>
    /// Multisurface or composite surface..
    /// </summary>
    public class MultiSurfaceBoundary : List<SurfaceBoundary>
    {

    }
    public class SurfaceBoundary : List<PointListBoundary>
    {

    }
    public class PointListBoundary : List<int>
    {
    }
}
