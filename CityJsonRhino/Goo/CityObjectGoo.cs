using CityJsonRhino.Common;
using CityJsonRhino.Model;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Goo
{
    public class CityObjectGoo : BaseGoo<CityObject>
    {
        public override IGH_Goo Duplicate(CityObject oldValue)
        {
            return new CityObjectGoo()
            {
                Value = new CityObject(oldValue),
            };
        }
    }
}