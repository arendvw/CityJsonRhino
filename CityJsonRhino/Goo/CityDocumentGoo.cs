using CityJsonRhino.Common;
using CityJsonRhino.Model;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Goo
{
    public class CityDocumentGoo : BaseGoo<CityDocument>
    {
        public override IGH_Goo Duplicate(CityDocument oldValue)
        {
            return new CityDocumentGoo()
            {
                Value = new CityDocument(oldValue),
            };
        }
    }
}