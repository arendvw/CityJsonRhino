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
    public class CityObjectDeconstruct : GH_Component
    {
        public CityObjectDeconstruct() : base(
            name: "Deconstruct CityObject",
            nickname: "DecoCityObject",
            description: "Deconstruct CityJSON Object",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{7368322C-972A-4457-ADB6-A5DB0CCDCCA2}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new CityObjectParam(), "CityObject", "CO", "CityObject", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Id", "I", "Id", GH_ParamAccess.item);
            pManager.AddTextParameter("Lod", "L", "Lod", GH_ParamAccess.item);
            pManager.AddTextParameter("Type", "T", "Type", GH_ParamAccess.item);
            pManager.AddParameter(new CityGeometryParam(), "Geometry", "G", "Geometry", GH_ParamAccess.item);
            pManager.AddTextParameter("Address", "A", "Address", GH_ParamAccess.item);
            pManager.AddPointParameter("AddressLocation", "AL", "Address Location", GH_ParamAccess.list);
            pManager.AddTextParameter("Children", "C", "Children", GH_ParamAccess.list);
            pManager.AddTextParameter("Parents", "P", "Parents", GH_ParamAccess.list);
            pManager.AddTextParameter("Attribute Keys", "K", "Attribute Keys", GH_ParamAccess.list);
            pManager.AddTextParameter("Attribute Values", "V", "Attribute Values", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var file = da.Fetch<CityObject>("CityObject");
            if (file == null)
            {
                return;
            }
            da.SetData("Id", file.Id);
            da.SetData("Lod", file.Lod);
            da.SetData("Type", file.Type);
            da.SetDataList("AddressLocation", file.Address?.Location);
            da.SetData("Address", file.Address?.ToString());
            da.SetDataList("Geometry", file.Geometry);
            da.SetDataList("Children", file.Children);
            da.SetDataList("Parents", file.Parents);
            da.SetDataList("Attribute Keys", file.Attributes?.Keys);
            da.SetDataList("Attribute Values", file.Attributes?.Values);
        }
    }
}

