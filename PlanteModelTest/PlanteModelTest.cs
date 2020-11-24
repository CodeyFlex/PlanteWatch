using Microsoft.VisualStudio.TestTools.UnitTesting;

//Testing this
using ModelLib.Model;

namespace PlanteModelTest
{
    [TestClass]
    public class PlanteModelTest
    {
        //Instance of PlanteModel to be tested
        private PlanteModel _planteModel = new PlanteModel();

        [TestMethod]
        public void PlanteHumidityTest()
        {
            _planteModel.Humidity = 35;
            Assert.AreEqual(35, _planteModel.Humidity);
        }

        [TestMethod]
        public void PlanteIdTest()
        {
            _planteModel.Id = 1;
            Assert.AreEqual(1, _planteModel.Id);
        }
    }
}