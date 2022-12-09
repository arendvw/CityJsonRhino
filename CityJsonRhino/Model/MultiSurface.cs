using System.Collections.Generic;
using System.Linq;
using CityJSON;
using CityJSON.Geometry.Semantics;

namespace CityJsonRhino.Model
{
    public class MultiSurface
    {
        public MultiSurface()
        {

        }

        public MultiSurface(MultiSurface srf)
        {
            Faces = srf.Faces.ToList();
        }

        public List<Face> Faces { get; set; } = new List<Face>();

        public override string ToString()
        {
            return $"Multisurface with {Faces.Count} faces";
        }

        public IEnumerable<Face> GetFaces()
        {
            return Faces;
        }

        public MultiSurfaceBoundary SaveToDocument(CityJsonDocument cityJsonDoc, ref SemanticsList<List<List<int?>>> solidSemantics)
        {
            var multiSurfaceBoundary = new MultiSurfaceBoundary();
            solidSemantics.Values.Add(new List<int?>());
            foreach (var item in Faces)
            {
                multiSurfaceBoundary.Add(item.SaveToDocument(cityJsonDoc, ref solidSemantics));
            }

            return multiSurfaceBoundary;
        }
    }
}