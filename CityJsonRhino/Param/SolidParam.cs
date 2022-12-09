using System;
using System.Collections.Generic;
using CityJsonRhino.Goo;
using Grasshopper.Kernel;

namespace CityJsonRhino.Param
{
    /// <summary>
    /// A generic assembly parameter, this can be either a nested assembly, or a simple assembly.
    /// </summary>
    public class SolidParam : GH_PersistentParam<SolidGoo>
    {
        private static GH_InstanceDescription MyInstanceDescription =>
            new GH_InstanceDescription(
                "Solid",
                "S",
                "CityJson Solid", 
                CityJsonConfig.Category,
                CityJsonConfig.ParamCategory);
        public SolidParam() : base(MyInstanceDescription)
        {
        }

        public override Guid ComponentGuid => new Guid("{C12D75AF-C71B-430B-AA66-C76987886566}");

        // protected override Bitmap Icon => null;
        protected override GH_GetterResult Prompt_Singular(ref SolidGoo value)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Plural(ref List<SolidGoo> values)
        {
            return GH_GetterResult.cancel;
        }
    }
}

