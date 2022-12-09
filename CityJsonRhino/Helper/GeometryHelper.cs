using System.Collections.Generic;
using System.Linq;
using CityJSON;
using Rhino.Geometry;

namespace CityJsonRhino.Helper
{
    public static class BoundaryHelper
    {
        /// <summary>
        /// First polyline is outer, rest are inner polylines.
        /// </summary>
        /// <param name="boundary"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static IEnumerable<Polyline> ToPolyline(this SurfaceBoundary boundary, CityJsonDocument doc)
        {
            return boundary.Select(item =>
            {
                var points = doc.GetVertices(item).ToPoint3dList();
                points.Add(points[0]);
                return new Polyline(points);
            });
        }
    }
}