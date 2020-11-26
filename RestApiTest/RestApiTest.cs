using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//Testing this
using ModelLib.Model;
using RestApi.Controllers;

namespace RestApiTest
{
    [TestClass]
    public class RestApiTest
    {
        //Instance of PlanteModel to be tested
        private PlanteWatchController _planteWatchController = new PlanteWatchController();

        //Instance of PlanteModel to be tested
        private PlanteModel _planteModel = new PlanteModel();

        [TestMethod]
        public void GetPlantsTest()
        {
            Assert.AreEqual(5, _planteWatchController.GetPlants().Count());
        }

        [TestMethod]
        public void GetGreenhousesTest()
        {
            Assert.AreEqual(3, _planteWatchController.GetGreenhouses().Count());
        }

        [TestMethod]
        public void GetPlantsByIdTest()
        {
            Assert.AreEqual(3, _planteWatchController.GetPlantById(3).Id);
            Assert.AreEqual(44, _planteWatchController.GetPlantById(3).Humidity);
        }

        [TestMethod]
        public void GetPlantsByHumidityTest()
        {
            Assert.AreEqual(1, _planteWatchController.GetPlantsByHumidity(35).Count());
        }
    }
}