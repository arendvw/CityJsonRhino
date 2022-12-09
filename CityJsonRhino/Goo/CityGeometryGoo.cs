using CityJsonRhino.Common;
using CityJsonRhino.Model;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Goo
{
    public class CityGeometryGoo : BaseGoo<CityGeometry>
    {
        public override IGH_Goo Duplicate(CityGeometry oldValue)
        {
            return new CityGeometryGoo()
            {
                Value = new CityGeometry(oldValue),
            };
        }
    }
}