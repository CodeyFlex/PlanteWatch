using Microsoft.VisualStudio.TestTools.UnitTesting;

//Testing this
using ModelLib.Model;

namespace GreenhouseModelTest
{
    [TestClass]
    public class GreenhouseModelTest
    {
        //Instance of PlanteModel to be tested
        private GreenhouseModel _greenhouseModel = new GreenhouseModel();

        [TestMethod]
        public void GreenhouseIdTest()
        {
            _greenhouseModel.Id = 1;
            Assert.AreEqual(1, _greenhouseModel.Id);
        }

        [TestMethod]
        public void GreenhouseNameTest()
        {
            _greenhouseModel.Name = "Test Greenhouse";
            Assert.AreEqual("Test Greenhouse", _greenhouseModel.Name);
        }

        [TestMethod]
        public void GreenhouseHumidityTest()
        {
            _greenhouseModel.Humidity = 45;
            Assert.AreEqual(45, _greenhouseModel.Humidity);
        }

        [TestMethod]
        public void GreenhouseTemperatureTest()
        {
            _greenhouseModel.Temperature = 12;
            Assert.AreEqual(12, _greenhouseModel.Temperature);
        }

        [TestMethod]
        public void GreenhouseLightLevelTest()
        {
            _greenhouseModel.LightLevel = 15;
            Assert.AreEqual(15, _greenhouseModel.LightLevel);
        }
    }
}
