using System;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;

namespace CityJsonRhino.Components
{
    public class FaceDeconstruct : GH_Component
    {
        public FaceDeconstruct() : base(
            name: "Deconstruct Face",
            nickname: "DecoFace",
            description: "Deconstruct CityJSON Face",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{A94E9FE2-FE95-43FA-AA48-09A2850AA617}");

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new FaceParam(), "Face", "F", "CityJSON Face geometry", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param_Curve(), "Outer", "O", "Outer curve of a face", GH_ParamAccess.item);
            pManager.AddParameter(new Param_Curve(), "Inner", "I", "Inner curve of a face", GH_ParamAccess.list);
            pManager.AddParameter(new Param_String(), "Keys", "K", "Keys of a face", GH_ParamAccess.list);
            pManager.AddParameter(new Param_String(), "Values", "V", "Values of a face", GH_ParamAccess.list);
            pManager.AddParameter(new Param_String(), "Type", "Type", "Type of a face", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            try
            {
                var file = da.Fetch<Face>("Face");
                if (file == null)
                {
                    return;
                }

                da.SetData("Outer", file.Outer);
                da.SetDataList("Inner", file.Inner);
                da.SetDataList("Keys", file.Semantics?.Attributes?.Keys);
                da.SetDataList("Values", file.Semantics?.Attributes?.Values);
                da.SetData("Type", file.Semantics?.Type);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Object to set to instance of reference" + ex.StackTrace);
            }
        }
    }
}

