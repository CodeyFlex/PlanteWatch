using System;
using System.Collections.Generic;
using System.Text;
using ModelLib.Model;
using RestApi.Controllers;

namespace TCP_Server
{
    public class StatusGetter
    {

        //Instance of PlanteWatchController
        private PlanteWatchController _planteWatchController = new PlanteWatchController();

        public void GetPlantValues(int plantId, string plantName, int plantHumidity, int plantNutrition)
        {
            Random rando = new Random();
            int plantHumidityRando = rando.Next(0, 2) * 2 - 1;
            int plantNutritionRando = rando.Next(0, 2) * 2 - 1;

            PlanteModel planteModel = new PlanteModel(plantId, plantName, plantHumidity + plantHumidityRando, plantNutrition + plantNutritionRando);
            Console.WriteLine("New Plant model: " + planteModel + "\n");
            _planteWatchController.PutPlant(plantId, planteModel);
        }

        public void GetGreenhouseValues(int greenhouseId, string greenhouseName, int greenhouseHumidity, int greenhouseTemperature, int greenhouseLightLevel)
        {
            Random rando = new Random();
            int greenhouseHumidityRando = rando.Next(0, 2) * 2 - 1;
            int greenhouseTemperatureRando = rando.Next(0, 2) * 2 - 1;
            int greenhouseLightLevelRando = rando.Next(0, 2) * 2 - 1;

            GreenhouseModel greenhouseModel = new GreenhouseModel(greenhouseId, greenhouseName, greenhouseHumidity + greenhouseHumidityRando, greenhouseTemperature + greenhouseTemperatureRando, greenhouseLightLevel + greenhouseLightLevelRando);
            Console.WriteLine("New Greenhouse model: " + greenhouseModel + "\n");
            _planteWatchController.PutGreenhouse(greenhouseId, greenhouseModel);
        }
    }
}
