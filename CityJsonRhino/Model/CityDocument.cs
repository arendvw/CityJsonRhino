using System.Collections.Generic;
using System.Linq;
using CityJSON;

using Rhino.Geometry;
using Transform = Rhino.Geometry.Transform;

namespace CityJsonRhino.Model
{
    public class CityDocument
    {

        public CityDocument()
        {

        }

        public CityDocument(CityDocument doc)
        {
            if (doc == null)
            {
                return;
            }
            Objects = doc.Objects?.ToList();
            Transform = doc.Transform;
            CoordinateSystem = doc.CoordinateSystem;
        }

        public CityJsonDocument ToJson()
        {
            var cityJsonDoc = new CityJsonDocument
            {
                Vertices = new List<Vertex>(),
                Metadata = new Metadata()
                {
                    ReferenceSystem = "urn:ogc:def:crs:EPSG::28992",
                },
                Transform = new CityJSON.Transform
                {
                    Scale = new List<double> {1, 1, 1}, Translate = new List<double> {0, 0, 0}
                }
            };
            // set metadata..

            // cityJsonDoc.Vertices // fix all vertices afterwards!



            // Renumber objects if they have duplicate keys
            var savedObjects = SaveObjectsToDocument(cityJsonDoc);
            var lookup = savedObjects.ToLookup(k => k.Id);
            var idx = 0;
            bool renumberedObjects = false;
            foreach (var group in lookup)
            {
                var itemInList = 0;
                foreach (var obj in group)
                {
                    if (obj.Id == null || itemInList > 0)
                    {

                        obj.Id = $"ID_{idx++}";
                        renumberedObjects = true;
                    }
                    itemInList++;
                }
            }
            
            cityJsonDoc.CityObjects = lookup.SelectMany(gr => gr).ToDictionary(k => k.Id, k=> k);

            
            cityJsonDoc.Metadata.PresentLoDs = cityJsonDoc
                .CityObjects
                .SelectMany(c => c.Value.Geometry)
                .GroupBy(g => g.Lod).ToDictionary(c => c.Key, v => v.Count());
            cityJsonDoc.Metadata.GeographicalExtent = Helper.BoundingBoxHelper.ToExtends(GetBoundingBox());
            return cityJsonDoc;
        }

        private BoundingBox GetBoundingBox()
        {
            var bbox = BoundingBox.Empty;
            foreach (var item in Objects.SelectMany(o => o.Geometry).Where(g => g != null))
            {
                bbox.Union(item.GetBoundingBox());
            }

            return bbox;
        }

        private IEnumerable<CityJsonObject> SaveObjectsToDocument(CityJsonDocument cityJsonDoc)
        {
            if (Objects == null)
            {
                yield break;
            }
            foreach (var item in Objects)
            {
                yield return item.SaveTo(cityJsonDoc);
            }
        }


        public static CityDocument FromJson(CityJsonDocument obj)
        {
            var doc = new CityDocument {CoordinateSystem = obj.Metadata.ReferenceSystem};

            if (obj.Transform != null)
            {
                var transformScale = Transform.Scale(Plane.WorldXY, obj.Transform.Scale[0], obj.Transform.Scale[1],
                    obj.Transform.Scale[2]);
                var transformMove = Transform.Translation(obj.Transform.Translate[0], obj.Transform.Translate[1],
                    obj.Transform.Translate[2]);
                // could be the other way around..
                doc.Transform = transformScale * transformMove;
            }

            if (obj.Metadata != null)
            {
                doc.Metadata = obj.Metadata;
            }

            doc.Objects = LoadObjects(obj).ToList();
            return doc;
        }

        public Metadata Metadata { get; set; }

        private static IEnumerable<CityObject> LoadObjects(CityJsonDocument cityJsonDocument)
        {
            foreach (var item in cityJsonDocument.CityObjects)
            {
                yield return CityObject.LoadFrom(item.Key, item.Value, cityJsonDocument);
            }
        }


        public List<CityObject> Objects { get; set; } = new List<CityObject>();
        public Transform Transform { get; set; }
        public string CoordinateSystem { get; set; }

        public override string ToString()
        {
            return $"CityJSON {Objects.Count} objects";
        }
    }
}
