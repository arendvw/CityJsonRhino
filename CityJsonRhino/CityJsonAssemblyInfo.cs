using System;
using Grasshopper.Kernel;

namespace CityJsonRhino
{
    public class CityJsonAssemblyInfo : GH_AssemblyInfo
    {
        public override string Description => "A Parser for CityJSON documents";

        // public override Bitmap Icon => Icons.Icon_Offset;

        public override string Name => "CityJson";

        public override string Version => "1.0.0";

        public override Guid Id => new Guid("{CEDD995B-756E-4DF4-8272-7605DE018921}");

        public override string AuthorName => "Arend van Waart";

        public override string AuthorContact => "arend@studioavw.nl";
    }
}
