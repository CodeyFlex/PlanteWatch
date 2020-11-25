using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using System.Collections.Generic;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanteWatchController : ControllerBase
    {
        //List of Plant Data
        private static List<PlanteModel> _plantData = new List<PlanteModel>()
        {
            new PlanteModel(0, "Plant 1", 35, 10),
            new PlanteModel(1, "Plant 2", 38, 8),
            new PlanteModel(2, "Plant 3", 42, 9),
            new PlanteModel(3, "Plant 4", 44, 7),
            new PlanteModel(4, "Plant 5", 47, 2),
        };

        //List of Grenhouse Data
        private static List<GreenhouseModel> _greenhouseData = new List<GreenhouseModel>()
        {
            new GreenhouseModel(0, "Greenhouse 1", 35, 10, 5),
            new GreenhouseModel(1, "Greenhouse 2", 32, 9, 6),
            new GreenhouseModel(2, "Greenhouse 3", 37, 11, 5),
        };

        // GET: api/<PlanteWatchController>
        [HttpGet]
        public IEnumerable<PlanteModel> GetPlants()
        {
            return _plantData;
        }

        // GET: api/<PlanteWatchController>
        [HttpGet]
        public IEnumerable<GreenhouseModel> GetGreenhouses()
        {
            return _greenhouseData;
        }

        // GET api/<PlanteWatchController>/5
        [HttpGet("{id}")]
        public PlanteModel GetPlantById(int id)
        {
            return _plantData.Find(i => i.Id.Equals(id));
        }

        // GET api/<PlanteWatchController>/Humidity/35
        [HttpGet("Humidity/{Humidity}")]
        public IEnumerable<PlanteModel> GetPlantsByHumidity(int humidity)
        {
            return _plantData.FindAll(i => i.Humidity.Equals(humidity));
        }
    }
}