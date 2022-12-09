using System;
using Grasshopper.Kernel.Parameters;

namespace CityJsonRhino.Helper
{
    public static class EnumParamHelper
    {
        /// <summary>
        /// Iterates over an Enum type to add the named values to the integer param
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cfParam"></param>
        internal static void AddEnumOptionsToParam<T>(Param_Integer cfParam)
        {
            foreach (int cfType in Enum.GetValues(typeof(T)))
            {
                var name = $"{Enum.GetName(typeof(T), cfType)} ({cfType})";
                cfParam.AddNamedValue(name, cfType);
            }
        }
    }
}