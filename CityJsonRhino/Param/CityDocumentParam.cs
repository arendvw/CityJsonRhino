using System;
using System.Collections.Generic;
using CityJsonRhino.Goo;
using Grasshopper.Kernel;

namespace CityJsonRhino.Param
{
    /// <summary>
    /// A generic assembly parameter, this can be either a nested assembly, or a simple assembly.
    /// </summary>
    public class CityDocumentParam : GH_PersistentParam<CityDocumentGoo>
    {
        private static GH_InstanceDescription MyInstanceDescription =>
            new GH_InstanceDescription(
                "CityJson Document",
                "CityJsonDoc",
                "Contents of a city json file", 
                CityJsonConfig.Category,
                CityJsonConfig.ParamCategory);
        public CityDocumentParam() : base(MyInstanceDescription)
        {
        }

        public override Guid ComponentGuid => new Guid("{25378B8A-C957-4E9B-A593-0D55EB376A77}");

        // protected override Bitmap Icon => null;
        protected override GH_GetterResult Prompt_Singular(ref CityDocumentGoo value)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Plural(ref List<CityDocumentGoo> values)
        {
            return GH_GetterResult.cancel;
        }
    }
}

