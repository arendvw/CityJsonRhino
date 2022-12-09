using System;
using System.IO;
using CityJSON;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Newtonsoft.Json;

namespace CityJsonRhino.Components
{
    public class OpenDocumentComponent : GH_Component
    {
        public OpenDocumentComponent() : base(
            name: "Open CityJson file",
            nickname: "OpenCityJson",
            description: "Open city json files",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{36DD03B8-78C3-455C-A137-C0F476E84079}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Filename", "F", "Filename of CityJSON file", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new CityDocumentParam(), "Document", "D", "Document", GH_ParamAccess.item);
        }


        protected override void SolveInstance(IGH_DataAccess da)
        {
            try
            {

                var file = da.Fetch<string>("Filename");
                var data = File.ReadAllText(file);
                var assembly = typeof(JsonConvert).Assembly.Location;
                var doc = JsonConvert.DeserializeObject<CityJsonDocument>(data);
                var obj = CityDocument.FromJson(doc);
                da.SetData(0, obj);
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
        }
    }
}

