using System;
using System.Collections.Generic;
using CityJsonRhino.Goo;
using CityJsonRhino.Model;
using Grasshopper.Kernel;

namespace CityJsonRhino.Param
{
    /// <summary>
    /// A generic assembly parameter, this can be either a nested assembly, or a simple assembly.
    /// </summary>
    public class FaceParam : GH_PersistentParam<FaceGoo>
    {
        private static GH_InstanceDescription MyInstanceDescription =>
            new GH_InstanceDescription(
                "Face",
                "F",
                "CityJson Solid", 
                CityJsonConfig.Category,
                CityJsonConfig.ParamCategory);
        public FaceParam() : base(MyInstanceDescription)
        {
        }

        public override Guid ComponentGuid => new Guid("{71200838-8D38-4BB8-A1D7-182EB50F37DB}");

        // protected override Bitmap Icon => null;
        protected override GH_GetterResult Prompt_Singular(ref FaceGoo value)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Plural(ref List<FaceGoo> values)
        {
            return GH_GetterResult.cancel;
        }
    }
}

