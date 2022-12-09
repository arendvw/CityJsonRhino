using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CityJSON;
using CityJSON.Geometry;
using CityJsonRhino.Helper;
using Rhino.Geometry;

namespace CityJsonRhino.Model
{
    public class CityObject
    {
        public CityObject()
        {

        }

        public CityObject(CityObject old)
        {
            Id = old.Id;
            Type = old.Type;
            Children = old.Children?.ToList();
            Parents = old.Parents?.ToList();
            Address = new Address(old.Address);
            Attributes = old.Attributes?.ToDictionary(k => k.Key, v => v.Value);
            Lod = old.Lod;
            Geometry = old.Geometry?.ToList();
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public List<string> Children { get; set; }
        public List<string> Parents { get; set; }
        public Address Address { get; set; }
        public Dictionary<string,string> Attributes { get; set; }
        public List<CityGeometry> Geometry { get; set; }
        public string Lod { get; set; }

        public static CityObject LoadFrom(string id, CityJsonObject sourceObject, CityJsonDocument cityJsonDocument)
        {
            var obj = new CityObject
            {
                Id = id,
                Attributes = sourceObject.Attributes?.ToDictionary(k => k.Key, v => v.Value),
                Type = sourceObject.Type,
                Address = Address.LoadFrom(sourceObject.Address, cityJsonDocument),
                Geometry = new List<CityGeometry>(),
                Children = sourceObject.Children?.ToList(),
                Parents = sourceObject.Parents?.ToList(),
            };

            for (var i = 0; i < sourceObject.Geometry.Count; i++)
            {
                obj.Geometry.Add(CityGeometry.LoadGeometry(i, sourceObject, cityJsonDocument));
            }

            return obj;
        }

        public IEnumerable<Face> GetFaces()
        {
            if (Geometry == null)
            {
                yield break;
            }
            foreach (var geo in Geometry)
            {
                foreach (var face in geo.GetFaces())
                {
                    yield return face;
                }
            }
        }

        public CityJsonObject SaveTo(CityJsonDocument cityJsonDoc)
        {
            return new CityJsonObject
            {
                Id = Id,
                Address = new CityJSON.Address(),
                Attributes = Attributes.ToDictionary(k => k.Key, v => v.Value),
                Children = Children,
                Parents = Parents,
                Type = Type,
                Geometry = AddGeometryList(cityJsonDoc, Geometry).ToList(),
                GeographicalExtent = GetBoundingBox().ToExtends()

            };
        }

        private BoundingBox GetBoundingBox()
        {
            return new BoundingBox(Geometry.Where(g => g != null).SelectMany(g =>
                g.GetFaces().SelectMany(l => l.AllBoundaries).SelectMany(l => l.ToList())));
        }


        private IEnumerable<Geometry> AddGeometryList(CityJsonDocument cityJsonDoc, List<CityGeometry> itemGeometry)
        {
            if (itemGeometry == null)
            {
                yield break;
            }
            var idx = 0;
            foreach (var item in itemGeometry)
            {
                if (item == null)
                {
                    continue;
                }

                yield return item.AddToDocument(cityJsonDoc, idx++);
            }
        }
    }
}