using System;
using System.Collections.Generic;
using CityJsonRhino.Goo;
using Grasshopper.Kernel;

namespace CityJsonRhino.Param
{
    /// <summary>
    /// A generic assembly parameter, this can be either a nested assembly, or a simple assembly.
    /// </summary>
    public class CityGeometryParam : GH_PersistentParam<CityGeometryGoo>
    {
        private static GH_InstanceDescription MyInstanceDescription =>
            new GH_InstanceDescription(
                "CityJson Object",
                "CityGeometry",
                "CityJson geometry", 
                CityJsonConfig.Category,
                CityJsonConfig.ParamCategory);
        public CityGeometryParam() : base(MyInstanceDescription)
        {
        }

        public override Guid ComponentGuid => new Guid("{0ACDC1BB-BA4E-4161-B245-044ED84B1C75}");

        // protected override Bitmap Icon => null;
        protected override GH_GetterResult Prompt_Singular(ref CityGeometryGoo value)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Plural(ref List<CityGeometryGoo> values)
        {
            return GH_GetterResult.cancel;
        }
    }
}

