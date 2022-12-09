using CityJsonRhino.Common;
using CityJsonRhino.Model;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Goo
{
    public class SolidGoo : BaseGoo<Solid>
    {
        public override IGH_Goo Duplicate(Solid oldValue)
        {
            return new SolidGoo()
            {
                Value = new Solid(oldValue),
            };
        }
    }
}