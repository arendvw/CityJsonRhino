using System.Collections.Generic;

namespace CityJSON
{
    public partial struct CityObjectValue
    {
        public List<object> AnythingArray;
        public bool? Bool;
        public CityObjectClass CityObjectClass;
        public double? Double;
        public long? Integer;
        public string String;

        public static implicit operator CityObjectValue(List<object> anythingArray) => new CityObjectValue { AnythingArray = anythingArray };
        public static implicit operator CityObjectValue(bool myBool) => new CityObjectValue { Bool = myBool };
        public static implicit operator CityObjectValue(CityObjectClass cityObjectClass) => new CityObjectValue { CityObjectClass = cityObjectClass };
        public static implicit operator CityObjectValue(double myDouble) => new CityObjectValue { Double = myDouble };
        public static implicit operator CityObjectValue(long integer) => new CityObjectValue { Integer = integer };
        public static implicit operator CityObjectValue(string myString) => new CityObjectValue { String = myString };
        public bool IsNull => AnythingArray == null && Bool == null && CityObjectClass == null && Double == null && Integer == null && String == null;
    }
}