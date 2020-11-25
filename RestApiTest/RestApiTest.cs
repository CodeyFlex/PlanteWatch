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
        public void GetTest()
        {
            Assert.AreEqual(5, _planteWatchController.GetPlants().Count());
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Assert.AreEqual(3, _planteWatchController.GetById(3).Id);
            Assert.AreEqual(44, _planteWatchController.GetById(3).Humidity);
        }

        [TestMethod]
        public void GetByHumidityTest()
        {
            Assert.AreEqual(1, _planteWatchController.GetByHumidity(35).Count());
        }
    }
}