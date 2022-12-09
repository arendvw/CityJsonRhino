using System;
using System.Collections.Generic;
using System.Text;

namespace CityJsonAvw.Geometry
{
    /// <summary>
    /// Multiple disjoint surfaces
    /// </summary>
    public class MultiSurface : AbstractGeometry<List<List<List<int>>>>
    {
        // list of surfaces
            // first surface is the outer surface (clockwise to the normal)
            // second surface are the inner surfaces (counterclockwise to the normal)
    }
}
