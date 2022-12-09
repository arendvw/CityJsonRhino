using System;
using System.Collections.Generic;
using System.Linq;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;

namespace CityJsonRhino.Components
{
    public class SolidDeconstruct : GH_Component
    {
        public SolidDeconstruct() : base(
            name: "Deconstruct Solid",
            nickname: "DecoSolid",
            description: "Deconstruct CityJSON Solid",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{D5413EDF-4FD8-470D-8025-594F68F6D71A}");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new SolidParam(), "Solid", "S", "CityJSON Solid geometry", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new MultiSurfaceParam(), "OuterShell", "O", "Faces of the outer shell", GH_ParamAccess.item);
            pManager.AddParameter(new MultiSurfaceParam(), "InnerShells", "I", "Faces of the inner shell", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var file = da.Fetch<Solid>("Solid");
            if (file == null)
            {
                return;
            }
            da.SetData("OuterShell", file.Outer);
            da.SetDataList("InnerShells", file.Inner);
        }
    }
}

