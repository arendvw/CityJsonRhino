using System;
using System.Collections.Generic;
using System.Linq;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;

namespace CityJsonRhino.Components
{
    public class MultiSurfaceConstruct : GH_Component
    {
        public MultiSurfaceConstruct() : base(
            name: "Construct Multisurface",
            nickname: "ConMultiSrf",
            description: "Construct CityJSON MultiSurface",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{CD2F93EB-4DDE-49C5-886F-019A8D3BD012}");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new FaceParam(), "Faces", "F", "Faces of the MultiSurface", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new MultiSurfaceParam(), "MultiSurface", "M", "CityJSON Multisurface geometry", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var multisurface = new MultiSurface {Faces = da.FetchList<Face>("Faces")};
            if (multisurface.Faces.Count == 0)
            {
                return;
            }
            da.SetData("MultiSurface", multisurface);
        }
    }
}

