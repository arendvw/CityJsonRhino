using System;
using System.Collections.Generic;
using CityJSON.Geometry.Semantics;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Newtonsoft.Json.Linq;
using Rhino.Geometry;

namespace CityJsonRhino.Components
{
    public class FaceConstruct : GH_Component
    {
        public FaceConstruct() : base(
            name: "Construct Face",
            nickname: "ConFace",
            description: "Construct CityJSON Face",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{0844CCDB-4CF9-4AF3-83C5-E497E13F93FF}");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new Param_Curve(), "Outer", "O", "Outer curve of a face", GH_ParamAccess.item);
            pManager.AddParameter(new Param_Curve(), "Inner", "I", "Inner curve of a face", GH_ParamAccess.list);
            pManager.AddParameter(new Param_String(), "Keys", "K", "Keys of a face", GH_ParamAccess.list);
            pManager.AddParameter(new Param_String(), "Values", "V", "Values of a face", GH_ParamAccess.list);
            pManager.AddParameter(new Param_String(), "Type", "Type", "Type of a face", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new FaceParam(), "Face", "F", "CityJSON Face geometry", GH_ParamAccess.item);
        }

        private int idx = 0;
        protected override void SolveInstance(IGH_DataAccess da)
        {
            var file = new Face();

            var outer = da.Fetch<Curve>(0);
            var inner = da.FetchList<Curve>(1);
            var keys = da.FetchList<string>(2);
            var values = da.FetchList<string>(3);
            var type = da.Fetch<string>(4);

            if (type == null)
            {
                var a = 1;
            }
            else
            {
                var b = 2;
            }
            var semantics = new Semantics {Type = type, Attributes = new Dictionary<string, JToken>()};
            for (int i = 0; i < keys.Count; i++)
            {
                semantics.Attributes.Add(keys[i], values[i]);
            }

            if (outer == null)
            {
                return;
            }
            
            outer.TryGetPolyline(out var outerPl);
            List<Polyline> innerListPl = new List<Polyline>();
            foreach (var item in inner)
            {
                item.TryGetPolyline(out var innerPl);
                innerListPl.Add(innerPl);
            }

            {
                var face = new Face
                {
                    Outer = outerPl,
                    Inner = innerListPl,
                    Semantics = semantics,
                };

                da.SetData("Face", face);
            }
        }
    }
}

