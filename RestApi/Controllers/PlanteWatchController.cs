using System;
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
        [HttpGet("Plants/")]
        public IEnumerable<PlanteModel> GetPlants()
        {
            return _plantData;
        }

        // GET: api/<PlanteWatchController>
        [HttpGet("Greenhouses/")]
        public IEnumerable<GreenhouseModel> GetGreenhouses()
        {
            return _greenhouseData;
        }

        // GET api/<PlanteWatchController>/3
        [HttpGet("Plants/Id/{id}")]
        public PlanteModel GetPlantById(int id)
        {
            return _plantData.Find(i => i.Id.Equals(id));
        }

        // GET api/<PlanteWatchController>/3
        [HttpGet("Greenhouse/Id/{id}")]
        public GreenhouseModel GetGreenhouseById(int id)
        {
            return _greenhouseData.Find(i => i.Id.Equals(id));
        }

        // GET api/<PlanteWatchController>/2
        [HttpGet("Plant/Name/{name}")]
        public PlanteModel GetPlantByName(string name)
        {
            return _plantData.Find(i => i.Name.Contains(name));
        }

        // GET api/<PlanteWatchController>/1
        [HttpGet("Greenhouse/Name/{name}")]
        public GreenhouseModel GetGreenhouseByName(string name)
        {
            return _greenhouseData.Find(i => i.Name.Contains(name));
        }

        // Search api/<PlanteWatchController>/Humidity/35
        [HttpGet("Plants/Humidity/{Humidity}")]
        public IEnumerable<PlanteModel> GetPlantsByHumidity(int humidity)
        {
            return _plantData.FindAll(i => i.Humidity >= humidity);
        }

        // Search api/<PlanteWatchController>/Temperature/35
        [HttpGet("Greenhouses/Temperature/{Temperature}")]
        public IEnumerable<GreenhouseModel> GetGreenhousesByTemperature(int temperature)
        {
            return _greenhouseData.FindAll(i => i.Temperature >= temperature);
        }

        // GET api/<PlanteWatchController>/Temperature/35
        [HttpGet("Greenhouse/Temperature/{Temperature}")]
        public GreenhouseModel GetGreenhouseByTemperature(int temperature)
        {
            return _greenhouseData.Find(i => i.Temperature.Equals(temperature));
        }

        /* doesn't return some values for some reason
        // GET api/<PlanteWatchController>/Trefle/
        [HttpGet("Trefle/Name/{Name}")]
        public TrefleModel GetTreflePlantByName(string name)
        {
            return Worker.GetOnePlantAsync(name);
        }
        */

        // GET api/<PlanteWatchController>/Trefle/
        [HttpGet("Trefle/Name/{Name}")]
        public String GetTreflePlantByName(string name)
        {
            return Worker.GetOnePlantAsync(name);
        }

        // PUT/Update api/<FanController>/Greenhouse/Put/5
        [HttpPut("Greenhouse/Put/{id}")]
        public void PutGreenhouse(int id, [FromBody] GreenhouseModel value)
        {
            GreenhouseModel greenhouse = GetGreenhouseById(id);
            if (greenhouse != null)
            {
                greenhouse.Id = value.Id;
                greenhouse.Name = value.Name;
                greenhouse.Humidity = value.Humidity;
                greenhouse.Temperature = value.Temperature;
                greenhouse.LightLevel = value.LightLevel;
            }
        }

        // PUT/Update api/<FanController>/Plant/Put/5
        [HttpPut("Plant/Put/{id}")]
        public void PutPlant(int id, [FromBody] PlanteModel value)
        {
            PlanteModel plant = GetPlantById(id);
            if (plant != null)
            {
                plant.Id = value.Id;
                plant.Name = value.Name;
                plant.Humidity = value.Humidity;
                plant.Nutrition = value.Nutrition;
            }
        }
    }
}