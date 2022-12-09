using System;
using System.Collections.Generic;
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
    public class CityDocumentConstruct : GH_Component
    {
        public CityDocumentConstruct() : base(
            name: "Construct Document",
            nickname: "ConDoc",
            description: "Construct CityJSON Document",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{2523D894-554A-4873-91A9-BAB511B673AD}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new CityObjectParam(), "Object", "CO", "CityObject", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new CityDocumentParam(), "Document", "D", "Document", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var cityDocument = new CityDocument
            {
                Objects = da.FetchList<CityObject>("Object")
            };
            da.SetData("Document", cityDocument);
        }
    }
}

