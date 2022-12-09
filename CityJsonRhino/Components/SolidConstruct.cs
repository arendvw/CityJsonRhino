using System;
using System.Collections.Generic;
using System.Linq;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;

namespace CityJsonRhino.Components
{
    public class SolidConstruct : GH_Component
    {
        public SolidConstruct() : base(
            name: "Construct Solid",
            nickname: "ConSolid",
            description: "Construct CityJSON Solid",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{276C71D7-DD6E-4123-AC13-F67EB4F11983}");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new MultiSurfaceParam(), "OuterShell", "O", "Faces of the outer shell", GH_ParamAccess.item);
            var innerIdx = pManager.AddParameter(new MultiSurfaceParam(), "InnerShells", "I", "Faces of the inner shell", GH_ParamAccess.list);
            pManager[innerIdx].Optional = true;
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new SolidParam(), "Solid", "S", "CityJSON Solid geometry", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {

            var outerShell = da.Fetch<MultiSurface>("OuterShell");
            var innerShells = da.FetchList<MultiSurface>("InnerShells");

            var solid = new Solid {Outer = outerShell, Inner = innerShells};
            da.SetData("Solid", solid);
        }
    }
}

