using System;
using System.Collections.Generic;
using System.Linq;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Rhino.Geometry;

namespace CityJsonRhino.Components
{
    public class CityDocumentMesh : GH_Component
    {
        public CityDocumentMesh() : base(
            name: "Mesh CityDocument",
            nickname: "MeshDoc",
            description: "Mesh CityJSON Document",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{3FBB7FAD-9AAE-43FE-97E0-6D304E525B4E}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new CityDocumentParam(), "Document", "D", "Document", GH_ParamAccess.item);
            var itemIdx = pManager.AddParameter(new Param_String(), "Lod", "L", "Show LOD", GH_ParamAccess.item);
            pManager[itemIdx].Optional = true;
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param_Mesh(), "Mesh", "M", "Combined mesh", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var file = da.Fetch<CityDocument>("Document");
            var lod = da.Fetch<string>("Lod");

            var faces = new List<Face>();

            foreach (var geo in 
                file
                    .Objects
                    .SelectMany(obj => obj.Geometry.Where(geo => lod == null || geo.Lod == lod)))
            {
                faces.AddRange(geo.GetFaces());
            }

            var mesh = new Mesh();
            foreach (var face in faces)
            {
                face.AppendToMesh(mesh);
            }

            mesh.FaceNormals.ComputeFaceNormals();
            mesh.Normals.ComputeNormals();
            mesh.Vertices.CombineIdentical(false, true);
            da.SetData("Mesh", mesh);
        }
    }
}

