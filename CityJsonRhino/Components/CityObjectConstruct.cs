using System;
using System.Collections.Generic;
using System.IO;
using CityJSON;
using CityJSON.Geometry.Semantics;
using CityJsonRhino.Goo;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CityJsonRhino.Components
{
    public class CityObjectConstruct : GH_Component
    {
        public CityObjectConstruct() : base(
            name: "Construct CityObject",
            nickname: "ConCityObject",
            description: "Construct CityJSON Object",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{FDAD5478-A59A-47E2-87C0-062BE6421E88}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Id", "I", "Id", GH_ParamAccess.item);
            pManager.AddTextParameter("Lod", "L", "Lod", GH_ParamAccess.item);
            pManager.AddTextParameter("Type", "T", "Type", GH_ParamAccess.item);
            pManager.AddParameter(new CityGeometryParam(), "Geometry", "G", "Geometry", GH_ParamAccess.item);
            pManager.AddTextParameter("Children", "C", "Children", GH_ParamAccess.list);
            pManager.AddTextParameter("Parents", "P", "Parents", GH_ParamAccess.list);
            pManager.AddTextParameter("Attribute Keys", "K", "Attribute Keys", GH_ParamAccess.list);
            pManager.AddTextParameter("Attribute Values", "V", "Attribute Values", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new CityObjectParam(), "CityObject", "CO", "CityObject", GH_ParamAccess.item);

        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var cityObject = new CityObject
            {
                Id = da.Fetch<string>("Id"),
                Lod = da.Fetch<string>("Lod"),
                Type = da.Fetch<string>("Type"),
                Geometry = new List<CityGeometry> {da.Fetch<CityGeometry>("Geometry")},
                Children = da.FetchList<string>("Children"),
                Parents = da.FetchList<string>("Parents"),
                Attributes = new Dictionary<string, string>()
            };

            var keys = da.FetchList<string>("Attribute Keys");
            var values = da.FetchList<string>("Attribute Values");
            for (int i = 0; i < keys.Count; i++)
            {
                cityObject.Attributes.Add(keys[i], values[i]);
            }

            da.SetData("CityObject", cityObject);
        }
    }
}

