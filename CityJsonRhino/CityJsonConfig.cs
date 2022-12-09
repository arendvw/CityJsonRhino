namespace CityJsonRhino
{
    public  static class CityJsonConfig
    {
        public static string Category => "StudioAvw";
        public static string ConstructCategory => "CityJSON";
        public static string ParamCategory => "Param";
        public static string GeometryCategory => "Geometry";

        public static string NickName(string nickname)
        {
            return $"CS {nickname}";
        }
    }
}
