using System;
using System.Collections.Generic;
using System.Linq;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;

namespace CityJsonRhino.Components
{
    public class MultiSurfaceDeconstruct : GH_Component
    {
        public MultiSurfaceDeconstruct() : base(
            name: "Deconstruct Multisurface",
            nickname: "DecoMultiSrf",
            description: "Deconstruct CityJSON MultiSurface",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{D5B05F6E-760E-4F44-B25F-083B0EE0BF25}");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new MultiSurfaceParam(), "MultiSurface", "M", "CityJSON Multisurface geometry", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new FaceParam(), "Faces", "F", "Faces of the MultiSurface", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var file = da.Fetch<MultiSurface>("MultiSurface");
            if (file == null)
            {
                return;
            }

            da.SetDataList("Faces", file.Faces);
        }
    }
}

