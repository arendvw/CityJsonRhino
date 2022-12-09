using System;
using Grasshopper.Kernel;

namespace CityJsonRhino.Attributes
{
    /// <summary>
    /// Attribute to annotate the names that will be used in GH_Goo en GH_Param classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class GhParam : Attribute
    {
        public GhParam(string name, string nickname, string description)
        {
            Description = description;
            Name = name;
            NickName = nickname;
        }
        public string Description { get; set; }
        public string Name { get; set; }

        public string NickName { get; set; }

        public static GH_InstanceDescription GetParamDescription<T>(bool isParam = true)
        {
            var param = (GhParam)GetCustomAttribute(typeof(T), typeof(GhParam));
            if (param == null)
            {
                throw new Exception($"Param of type {typeof(T)} has no attribute GhParam");
            }
            var description = new GH_InstanceDescription
            {
                Category = CityJsonConfig.Category,
                SubCategory = isParam? CityJsonConfig.ParamCategory: CityJsonConfig.ConstructCategory,
                Description = param?.Description,
                Name = param?.Name,
                NickName = param?.NickName
            };
            return description;
        }
    }
}