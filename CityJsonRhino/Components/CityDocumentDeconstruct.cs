using System;
using System.IO;
using CityJSON;
using CityJsonRhino.Goo;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Newtonsoft.Json;

namespace CityJsonRhino.Components
{
    public class CityDocumentDeconstruct : GH_Component
    {
        public CityDocumentDeconstruct() : base(
            name: "Deconstruct Document",
            nickname: "DecoDoc",
            description: "Deconstruct CityJSON Document",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{5353F999-9A06-4EF1-8DB6-E27EA1837FF2}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new CityDocumentParam(), "Document", "D", "Document", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new CityObjectParam(), "Object", "CO", "CityObject", GH_ParamAccess.item);
            pManager.AddTextParameter("LOD", "LOD", "Available level of details", GH_ParamAccess.list);
            pManager.AddTextParameter("Reference", "R", "Coordinate system", GH_ParamAccess.item);
            pManager.AddTransformParameter("Transform", "T", "Transform", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var file = da.Fetch<CityDocument>("Document");
            da.SetDataList("Object", file.Objects);
            da.SetData("LOD", file.Metadata?.PresentLoDs?.Keys);
            da.SetData("Reference", file.Metadata?.ReferenceSystem);
            da.SetData("Transform", file.Transform);
        }
    }
}

