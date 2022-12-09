using System;
using System.Collections.Generic;
using System.IO;
using CityJSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TestCityJSON
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ReadRotterdam()
        {
            var data = File.ReadAllText(@"../../../../TestData/Lageland.json");
            var obj = JsonConvert.DeserializeObject<CityJsonDocument>(data);
            var text = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var obj2 = JsonConvert.DeserializeObject<CityJsonDocument>(text);
            Assert.AreEqual(obj.CityObjects.Count, obj2.CityObjects.Count);
        }

        [TestMethod]
        public void ReadRotterdamTwee()
        {
            var data = File.ReadAllText(@"../../../../TestData/Middelland.json");
            var obj = JsonConvert.DeserializeObject<CityJsonDocument>(data);
            var text = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var obj2 = JsonConvert.DeserializeObject<CityJsonDocument>(text);
            Assert.AreEqual(obj.CityObjects.Count, obj2.CityObjects.Count);
        }

        [TestMethod]
        public void ReadZBag3d()
        {
            var data = File.ReadAllText(@"../../../../TestData/3dbag_v21031_7425c21b_2995.json");
            var obj = JsonConvert.DeserializeObject<CityJsonDocument>(data);
            var text = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var obj2 = JsonConvert.DeserializeObject<CityJsonDocument>(text);
            Assert.AreEqual(obj.CityObjects.Count, obj2.CityObjects.Count);
        }

        [TestMethod]
        public void ReadZBag3dv2()
        {
            var data = File.ReadAllText(@"../../../../TestData/3dbag_v210908_fd2cee53_5881.json");
            var obj = JsonConvert.DeserializeObject<CityJsonDocument>(data);
            var text = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var obj2 = JsonConvert.DeserializeObject<CityJsonDocument>(text);
            Assert.AreEqual(obj.CityObjects.Count, obj2.CityObjects.Count);
        }
    }
}
