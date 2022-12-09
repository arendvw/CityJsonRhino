using System;
using System.Collections.Generic;
using CityJsonRhino.Goo;
using Grasshopper.Kernel;

namespace CityJsonRhino.Param
{
    /// <summary>
    /// A generic assembly parameter, this can be either a nested assembly, or a simple assembly.
    /// </summary>
    public class MultiSurfaceParam : GH_PersistentParam<MultiSurfaceGoo>
    {
        private static GH_InstanceDescription MyInstanceDescription =>
            new GH_InstanceDescription(
                "MultiSurface",
                "MultiSrf",
                "CityJson multisurface", 
                CityJsonConfig.Category,
                CityJsonConfig.ParamCategory);
        public MultiSurfaceParam() : base(MyInstanceDescription)
        {
        }

        public override Guid ComponentGuid => new Guid("{0E81DEF2-83AB-4015-ABEB-1F4B682FDC05}");

        // protected override Bitmap Icon => null;
        protected override GH_GetterResult Prompt_Singular(ref MultiSurfaceGoo value)
        {
            return GH_GetterResult.cancel;
        }

        protected override GH_GetterResult Prompt_Plural(ref List<MultiSurfaceGoo> values)
        {
            return GH_GetterResult.cancel;
        }
    }
}

