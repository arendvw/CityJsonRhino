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
    public class DocumentSaveComponent : GH_Component
    {
        public DocumentSaveComponent() : base(
            name: "Save CityJson file",
            nickname: "SaveCityJson",
            description: "Save city json files",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{168D8A00-59B0-4736-862C-1036EC03B585}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new CityDocumentParam(), "Document", "D", "Document", GH_ParamAccess.item);
            var idx = pManager.AddTextParameter("Filename", "F", "Filename of cityjson file", GH_ParamAccess.item);
            pManager[idx].Optional = true;
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Json", "J", "Json", GH_ParamAccess.item);
        }


        protected override void SolveInstance(IGH_DataAccess da)
        {
            try
            {
                var doc = da.Fetch<CityDocument>("Document");
                var file = da.Fetch<string>("Filename");
                var text = JsonConvert.SerializeObject(doc.ToJson(), Formatting.Indented);
                da.SetData("Json", text);
                if (file != null)
                {
                    try
                    {
                        File.WriteAllText(file, text);
                    }
                    catch (Exception ex)
                    {
                        AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Could not save file " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
        }
    }
}

