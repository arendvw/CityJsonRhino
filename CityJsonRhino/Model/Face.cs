using System.Collections.Generic;
using System.Linq;
using CityJSON;
using CityJSON.Geometry.Semantics;
using CityJsonRhino.Helper;
using Rhino.Collections;
using Rhino.Geometry;

namespace CityJsonRhino.Model
{
    public class Face
    {
        public Face()
        {

        }
        public Face(Face oldValue)
        {
            Inner = oldValue.Inner;
            Outer = oldValue.Outer;
            Semantics = oldValue.Semantics;
        }

        public Polyline Outer { get; set; }
        public List<Polyline> Inner { get; set; } = new List<Polyline>();
        public Semantics Semantics { get; set; }

        public IEnumerable<Polyline> AllBoundaries
        {
            get
            {
                if (Outer != null)
                {

                    yield return Outer;
                    if (Inner == null)
                    {
                        yield break;
                    }

                    foreach (var item in Inner)
                    {
                        yield return item;
                    }
                }
            }
        }
        public void AppendToMesh(Mesh mesh)
        {
            if (Inner == null || Inner.Count == 0)
            {
                if (Outer.Count == 5)
                {
                    // add quad
                    var startIdx = mesh.Vertices.Count;
                    mesh.Vertices.Add(Outer[0]);
                    mesh.Vertices.Add(Outer[1]);
                    mesh.Vertices.Add(Outer[2]);
                    mesh.Vertices.Add(Outer[3]);
                    mesh.Faces.AddFace(startIdx, startIdx + 1, startIdx + 2, startIdx + 3);
                    return;
                }

                if (Outer.Count == 4)
                {
                    var startIdx = mesh.Vertices.Count;
                    mesh.Vertices.Add(Outer[0]);
                    mesh.Vertices.Add(Outer[1]);
                    mesh.Vertices.Add(Outer[2]);
                    mesh.Faces.AddFace(startIdx, startIdx + 1, startIdx + 2);
                    return;
                }

                var subMesh = Mesh.CreateFromClosedPolyline(Outer);
                mesh.Append(subMesh);
            }
            else
            {
                // var subMesh = Mesh.CreateFromClosedPolyline(Outer);
                // mesh.Append(subMesh);
                var planarSrf = Brep.CreatePlanarBreps(new CurveList(Inner.Select(c => new PolylineCurve(c)).Union(new List<PolylineCurve>() { new PolylineCurve(Outer) })));
                if (planarSrf == null) return;
                foreach (var subMesh in planarSrf.SelectMany(Mesh.CreateFromBrep))
                {
                    mesh.Append(subMesh);
                }
            }
        }

        public SurfaceBoundary SaveToDocument(CityJsonDocument cityJsonDoc, ref SemanticsList<List<int?>> multisurfaceSemantics)
        {
            multisurfaceSemantics.Surfaces.Add(Semantics);
            multisurfaceSemantics.Values.Add(multisurfaceSemantics.Surfaces.Count -1);
            var surfaceBoundary = new SurfaceBoundary();
            foreach (var item in AllBoundaries)
            {
                surfaceBoundary.Add(SaveBoundaryToDocument(cityJsonDoc, item));
            }
            return surfaceBoundary;
        }


        public SurfaceBoundary SaveToDocument(CityJsonDocument cityJsonDoc, ref SemanticsList<List<List<int?>>> solidSemantics)
        {
            solidSemantics.Surfaces.Add(Semantics);
            solidSemantics.Values.Last().Add(solidSemantics.Surfaces.Count - 1);
            var surfaceBoundary = new SurfaceBoundary();
            foreach (var item in AllBoundaries)
            {
                if (item == null)
                {
                    continue;
                }
                surfaceBoundary.Add(SaveBoundaryToDocument(cityJsonDoc, item));
            }
            return surfaceBoundary;
        }

        private PointListBoundary SaveBoundaryToDocument(CityJsonDocument cityJsonDoc, Polyline item)
        {
            // all polylines are closed, last one is the same as the first in rhino.
            var startCount = cityJsonDoc.Vertices.Count;
            var length = item.Count-1;
            cityJsonDoc.Vertices.AddRange(item.Take(item.Count-1).ToVertexList());
            var boundary = new PointListBoundary();
            boundary.AddRange(Enumerable.Range(startCount, length));
            return boundary;
        }

    }
}