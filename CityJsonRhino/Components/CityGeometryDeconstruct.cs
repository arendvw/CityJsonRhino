using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CityJSON;
using CityJsonRhino.Goo;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Newtonsoft.Json;
using Rhino.Collections;
using Rhino.Geometry;

namespace CityJsonRhino.Components
{
    public class CityGeometryDeconstruct : GH_Component
    {
        public CityGeometryDeconstruct() : base(
            name: "Deconstruct CityGeometry",
            nickname: "DecoCityGeometry",
            description: "Deconstruct CityJSON Geometry",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{85611128-3023-4539-A10D-BC13B2D22F06}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddParameter(new CityGeometryParam(), "CityGeometry", "G", "City Geometry", GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Id", "I", "Id", GH_ParamAccess.item);
            pManager.AddTextParameter("Lod", "L", "Lod", GH_ParamAccess.item);
            pManager.AddTextParameter("Type", "T", "Type", GH_ParamAccess.item);
            pManager.AddParameter(new SolidParam(), "Solid", "S", "Faces", GH_ParamAccess.item);
            pManager.AddParameter(new MultiSurfaceParam(), "MultiSurface", "M", "Multisurface", GH_ParamAccess.item);
            pManager.AddParameter(new Param_Mesh(), "Mesh", "M", "Mesh", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            try
            {
                var file = da.Fetch<CityGeometry>("CityGeometry");
                if (file == null)
                {
                    return;
                }

                da.SetData("Id", file.Id);
                da.SetData("Lod", file.Lod);
                da.SetData("Type", file.Type);

                if (file.Solid != null || file.MultiSolid != null)
                {
                    var mesh = new Mesh();
                    foreach (var item in file.GetFaces())
                    {
                        if (item.Outer == null)
                        {
                            continue;
                        }

                        item.AppendToMesh(mesh);
                    }
                    
                    // mesh.FaceNormals.ComputeFaceNormals();
                    // mesh.Normals.ComputeNormals();
                    // mesh.Vertices.CombineIdentical(false, true);
                    da.SetData("Mesh", mesh);
                }

                if (file.Solid != null)
                {
                    da.SetData("Solid", file.Solid);
                }

                if (file.MultiSurface != null)
                {
                    da.SetData("MultiSurface", file.MultiSurface);
                }
            } catch (Exception ex)
            {
                throw;
            }
        }
    }
}

