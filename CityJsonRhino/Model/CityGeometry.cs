using System;
using System.Collections.Generic;
using System.Linq;
using CityJSON;
using CityJSON.Geometry;
using CityJSON.Geometry.Semantics;
using CityJsonRhino.Helper;
using Rhino.Geometry;

namespace CityJsonRhino.Model
{
    public class CityGeometry
    {
        public CityGeometry()
        {

        }
        public CityGeometry(CityGeometry oldValue)
        {
            Id = oldValue.Id;
            Type = oldValue.Type;
            Lod = oldValue.Lod;
            MultiSurface = oldValue.MultiSurface;
            Solid = oldValue.Solid;
            MultiSolid = oldValue.MultiSolid;
        }

        public string Id { get; set; }
        public CityGeometryType Type { get; set; }
        public string Lod { get; set; }
        /// <summary>
        /// Solid = multiple boundaries
        /// </summary>
        public MultiSurface MultiSurface { get; set; }
        public Solid Solid { get; set; }
        public MultiSolidBoundary MultiSolid { get; set; }

        public static CityGeometry LoadGeometry(int index, CityJsonObject obj, CityJsonDocument doc)
        {
            var geo = obj.Geometry[index];
            
            if (geo is SolidGeometry solid)
            {
                return LoadSolidGeometry(doc, solid);
            }
            if (geo is MultiSurfaceGeometry multisurface)
            {
                return LoadMultiSurface(doc, multisurface);
            }

            throw new NotImplementedException($"support for geometry {geo.GetType()} was not implemented");
        }

        private static CityGeometry LoadMultiSurface(CityJsonDocument doc, MultiSurfaceGeometry multisurface)
        {
            var cityGeo = new CityGeometry
            {
                Type = CityGeometryType.MultiSurface,
                Lod = multisurface.Lod,
                MultiSurface = new MultiSurface()
            };
            var semanticsObject = multisurface.Semantics;
            // solid has an outer shell and an inner shell..
            for (var srfIdx = 0; srfIdx < multisurface.Boundaries.Count; srfIdx++)
            {
                var surface = multisurface.Boundaries[srfIdx];
                var semanticsIdx = semanticsObject != null ? semanticsObject.Values[srfIdx] : null;
                var geometry = surface.ToPolyline(doc).ToList();
                var face = new Face
                {
                    Outer = geometry.First(),
                    Inner = geometry.Skip(1).ToList(),
                };
                if (semanticsIdx != null)
                {
                    face.Semantics = semanticsObject.Surfaces[(int) semanticsIdx];
                }

                cityGeo.MultiSurface.Faces.Add(face);
            }

            return cityGeo;
        }

        private static CityGeometry LoadSolidGeometry(CityJsonDocument doc, SolidGeometry solid)
        {
            var cityGeo = new CityGeometry
            {
                Type = CityGeometryType.Solid,
                Lod = solid.Lod,
                Solid = new Solid(),
            };

            var semanticsObject = solid.Semantics;
            // solid has an outer shell and an inner shell..
            for (var shellIdx = 0; shellIdx < solid.Boundaries.Count; shellIdx++)
            {
                var shell = solid.Boundaries[shellIdx];
                var multiSrf = new MultiSurface
                {
                    Faces = new List<Face>()
                };
                for (int i = 0; i < shell.Count; i++)
                {
                    var semanticsIdx = semanticsObject?.Values[shellIdx][i];
                    var geometry = shell[i].ToPolyline(doc).ToList();
                    var face = new Face
                    {
                        Outer = geometry.First(),
                        Inner = geometry.Skip(1).ToList(),
                    };
                    if (semanticsIdx != null)
                    {
                        face.Semantics = semanticsObject.Surfaces[(int) semanticsIdx];
                    }

                    multiSrf.Faces.Add(face);
                }

                if (shellIdx == 0)
                {
                    cityGeo.Solid.Outer = multiSrf;
                }
                else
                {
                    cityGeo.Solid.Inner.Add(multiSrf);
                }
            }

            return cityGeo;
        }

        public IEnumerable<Face> GetFaces()
        {
            if (Solid != null)
            {
                foreach (var face in Solid.GetFaces())
                {
                    yield return face;
                }
            }

            if (MultiSurface != null)
            {
                foreach (var face in MultiSurface.GetFaces())
                {
                    yield return face;
                }
            }

        }

        public Geometry AddToDocument(CityJsonDocument cityJsonDoc, int index)
        {
            if (Type == CityGeometryType.Solid)
            {
                return SaveSolidGeometry(cityJsonDoc);
            }
            if (Type == CityGeometryType.MultiSurface)
            {
                return SaveMultiSurface(cityJsonDoc);
            }

            throw new NotImplementedException($"support for geometry {Type} was not implemented");
        }

        private Geometry SaveMultiSurface(CityJsonDocument cityJsonDoc)
        {
            var semantics = new SemanticsList<List<int?>>
            {
                Surfaces = new List<Semantics>(),
                Values = new List<int?>()
            };
            var multiSurface = new MultiSurfaceGeometry()
            {
                Lod = Lod,
                Boundaries = new MultiSurfaceBoundary(),
                Semantics = semantics
            };

            if (MultiSurface == null) return multiSurface;
            foreach (var item in MultiSurface.Faces)
            {
                multiSurface.Boundaries.Add(item.SaveToDocument(cityJsonDoc, ref semantics));
            }

            return multiSurface;
        }

        private Geometry SaveSolidGeometry(CityJsonDocument cityJsonDoc)
        {
            var semantics = new SemanticsList<List<List<int?>>>
            {
                Surfaces = new List<Semantics>(), Values = new List<List<int?>>()
            };
            var solid = new SolidGeometry()
            {
                Lod = Lod,
                Semantics = semantics,
                Boundaries = new SolidBoundary(),
            };


            foreach (var item in Solid.AllMultiSurfaces)
            {
                solid.Boundaries.Add(item.SaveToDocument(cityJsonDoc, ref semantics));
            }

            return solid;
        }

        public BoundingBox GetBoundingBox()
        {
            return new BoundingBox(GetFaces().SelectMany(f => f.AllBoundaries).SelectMany(pl => pl.ToList()));
        }
    }
}