using CityJsonRhino.Common;
using CityJsonRhino.Model;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Goo
{
    public class MultiSurfaceGoo : BaseGoo<MultiSurface>
    {
        public override IGH_Goo Duplicate(MultiSurface oldValue)
        {
            return new MultiSurfaceGoo()
            {
                Value = new MultiSurface(oldValue),
            };
        }
    }
}