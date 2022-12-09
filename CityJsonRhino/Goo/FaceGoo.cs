using CityJsonRhino.Common;
using CityJsonRhino.Model;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Goo
{
    public class FaceGoo : BaseGoo<Face>
    {
        public override IGH_Goo Duplicate(Face oldValue)
        {
            return new FaceGoo()
            {
                Value = new Face(oldValue),
            };
        }
    }
}