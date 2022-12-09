using System.Collections.Generic;
using System.Linq;
using CityJSON;
using Rhino.DocObjects.Tables;
using Rhino.Geometry;

namespace CityJsonRhino.Helper
{
    public static class BoundingBoxHelper
    {
        public static List<double> ToExtends(this BoundingBox bbox)
        {
            return new List<double> { bbox.Min.X, bbox.Min.Y, bbox.Min.Z, bbox.Max.X, bbox.Max.Y, bbox.Max.Z };
        }
    }

    public static class VertexHelper
    {
        /// <summary>
        /// Iterates over an Enum type to add the named values to the integer param
        /// </summary>
        /// <param name="vertex"></param>
        public static Point3d ToPoint3d(this Vertex vertex)
        {
            return new Point3d(vertex.X, vertex.Y, vertex.Z);
        }

        public static Vertex ToVertex(this Point3d pt)
        {
            return new Vertex { X = pt.X, Y = pt.Y, Z = pt.Z};
        }


        public static List<Point3d> ToPoint3dList(this IEnumerable<Vertex> vertices)
        {
            return vertices.Select(ToPoint3d).ToList();
        }

        public static List<Vertex> ToVertexList(this IEnumerable<Point3d> vertices)
        {
            return vertices.Select(ToVertex).ToList();
        }


    }
}