using System;
using System.Collections.Generic;
using System.Text;

namespace CityJsonAvw.Geometry
{
    public class AbstractGeometry<T>
    {
        public string Type { get; set; }
        public double Lod { get; set; }
        public IEnumerable<T> Boundaries { get; set; }
    }
}
