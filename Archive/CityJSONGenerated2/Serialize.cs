using Newtonsoft.Json;

namespace CityJSON
{
    public static class Serialize
    {
        public static string ToJson(this Coordinate self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}