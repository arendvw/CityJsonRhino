using System;
using CityJsonRhino.Helper;
using CityJsonRhino.Model;
using CityJsonRhino.Param;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace CityJsonRhino.Components
{
    public class CityGeometryConstruct : GH_Component
    {
        public CityGeometryConstruct() : base(
            name: "Construct CityGeometry",
            nickname: "ConCityGeometry",
            description: "Construct CityJSON Geometry",
            category: CityJsonConfig.Category,
            subCategory: CityJsonConfig.ConstructCategory
        )
        {
        }

        public override Guid ComponentGuid => new Guid("{5066C5F3-4D28-4823-928F-C3A3EA56E1CB}");

        //protected override Bitmap Icon => Icons.AssemblyConstructLayered;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Id", "I", "Id", GH_ParamAccess.item);
            pManager.AddTextParameter("Lod", "L", "Lod", GH_ParamAccess.item);
            pManager.AddTextParameter("Type", "T", "Type", GH_ParamAccess.item);
            {
                var paramIdx = pManager.AddParameter(new SolidParam(), "Solid", "S", "Faces", GH_ParamAccess.item);
                pManager[paramIdx].Optional = true;
            }
            {
                var paramIdx = pManager.AddParameter(new MultiSurfaceParam(), "MultiSurface", "M", "Multisurface", GH_ParamAccess.item);
                pManager[paramIdx].Optional = true;
            }

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new CityGeometryParam(), "CityGeometry", "G", "City Geometry", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            var id = da.Fetch<string>("Id");
            var lod = da.Fetch<string>("Lod");
            var type = da.Fetch<string>("Type");
            var solid = da.Fetch<Solid>("Solid");
            var multiSurface = da.Fetch<MultiSurface>("MultiSurface");

            if (type == "Solid")
            {
                var cityGeometry = new CityGeometry()
                {
                    Id = id,
                    Lod = lod,
                    Solid = solid,
                    MultiSurface = null,
                    Type = CityGeometryType.Solid
                };
                da.SetData("CityGeometry", cityGeometry);
            }
            else
            {
                var cityGeometry = new CityGeometry()
                {
                    Id = id,
                    Lod = lod,
                    Solid = null,
                    MultiSurface = multiSurface,
                    Type = CityGeometryType.MultiSurface,
                };
                da.SetData("CityGeometry", cityGeometry);
            }
        }
    }
}

