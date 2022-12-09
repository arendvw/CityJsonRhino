using Rhino;

namespace CityJsonRhino.Helper
{
    public static class DocHelper
    {
        /// <summary>
        /// Safely get model tolerance -- use the active RhinoDoc where present, otherwise return a default.
        /// </summary>
        /// <returns></returns>
        public static double GetModelTolerance()
        {
            return RhinoDoc.ActiveDoc?.ModelAbsoluteTolerance ?? 0.01;
        }
    }
}