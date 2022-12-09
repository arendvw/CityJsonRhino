using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CityJsonRhino.Model
{
    public class Solid
    {
        public Solid()
        {

        }

        public Solid(Solid oldValue)
        {
            Outer = oldValue.Outer;
            Inner = oldValue.Inner?.ToList();
        }

        public MultiSurface Outer { get; set; }
        public List<MultiSurface> Inner { get; set; } = new List<MultiSurface>();

        public IEnumerable<MultiSurface> AllMultiSurfaces
        {
            get
            {
                if (Outer != null)
                {
                    yield return Outer;
                }

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

        public override string ToString()
        {
            return $"Solid with {Outer.Faces.Count} outer faces and {Inner.Count} inner faces";
        }

        public IEnumerable<Face> GetFaces()
        {
            if (Outer != null)
            {
                foreach (var item in Outer.Faces)
                {
                    yield return item;
                }
            }
            if (Inner != null)
            {
                
                foreach (var multi in Inner)
                {
                    foreach (var face in multi.Faces)
                    {
                        yield return face;
                    }
                }
            }
        }
    }
}