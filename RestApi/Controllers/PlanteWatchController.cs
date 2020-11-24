using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanteWatchController : ControllerBase
    {
        //List of Data
        private static List<PlanteModel> _planteData = new List<PlanteModel>()
        {
            new PlanteModel(0, 35),
            new PlanteModel(1, 38),
            new PlanteModel(2, 42),
            new PlanteModel(3, 44),
            new PlanteModel(4, 47),
        };

        // GET: api/<PlanteWatchController>
        [HttpGet]
        public IEnumerable<PlanteModel> Get()
        {
            return _planteData;
        }

        // GET api/<PlanteWatchController>/5
        [HttpGet("{id}")]
        public PlanteModel GetById(int id)
        {
            return _planteData.Find(i => i.Id.Equals(id));
        }

        // GET api/<PlanteWatchController>/Humidity/35
        [HttpGet("Humidity/{Humidity}")]
        public IEnumerable<PlanteModel> GetByHumidity(int humidity)
        {
            return _planteData.FindAll(i => i.Humidity.Equals(humidity));
        }
    }
}