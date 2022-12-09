using System;
using System.Collections.Generic;
using CityJsonRhino.Goo;
using Grasshopper.Kernel;

namespace CityJsonRhino.Param
{
    /// <summary>
    /// A generic assembly parameter, this can be either a nested assembly, or a simple assembly.
    /// </summary>
    public class CityObjectParam : GH_PersistentParam<CityObjectGoo>
    {
        private static GH_InstanceDescription MyInstanceDescription =>
            new GH_InstanceDescription(
                "CityJson Object",
                "CityGeometry",
                "CityJson geometry", 
                CityJsonConfig.Category,
                CityJsonConfig.ParamCategory);
        public CityObjectParam() : base(MyInstanceDescription)
        {
        }

        public override Guid ComponentGuid => new Guid("{3162FB8D-E504-4D42-8021-7C7DEA4F949B}");

        // protected override Bitmap Icon => null;
        protected override GH_GetterResult Prompt_Singular(ref CityObjectGoo value)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Plural(ref List<CityObjectGoo> values)
        {
            return GH_GetterResult.cancel;
        }
    }
}

