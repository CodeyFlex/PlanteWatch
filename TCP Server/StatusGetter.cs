using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ModelLib.Model;
using Newtonsoft.Json;
using RestApi.Controllers;

namespace TCP_Server
{
    public class StatusGetter
    {
        //Instance of PlanteWatchController
        private PlanteWatchController _planteWatchController = new PlanteWatchController();

        private static String _uriPutGreenhouse = "http://localhost:51283/api/PlanteWatch/Greenhouse/Put/";

        public async void GetPlantValues(int plantId, string plantName, int plantHumidity, int plantNutrition)
        {
            Random rando = new Random();
            int plantHumidityRando = rando.Next(0, 2) * 2 - 1;
            int plantNutritionRando = rando.Next(0, 2) * 2 - 1;

            PlanteModel planteModel = new PlanteModel(plantId, plantName, plantHumidity + plantHumidityRando, plantNutrition + plantNutritionRando);
            Console.WriteLine("New Plant model: " + planteModel + "\n");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51283/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Sending PUT");
                HttpResponseMessage response = await client.PutAsJsonAsync("api/PlanteWatch/Plant/Put/" + plantId, planteModel);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success!");
                }
            }
        }

        public async void GetGreenhouseValues(int greenhouseId, string greenhouseName, int greenhouseHumidity,
            int greenhouseTemperature, int greenhouseLightLevel)
        {
            Random rando = new Random();
            int greenhouseHumidityRando = rando.Next(0, 2) * 2 - 1;
            int greenhouseTemperatureRando = rando.Next(0, 2) * 2 - 1;
            int greenhouseLightLevelRando = rando.Next(0, 2) * 2 - 1;

            GreenhouseModel greenhouseModel = new GreenhouseModel(greenhouseId, greenhouseName,
                greenhouseHumidity + greenhouseHumidityRando, greenhouseTemperature + greenhouseTemperatureRando,
                greenhouseLightLevel + greenhouseLightLevelRando);
            Console.WriteLine("New Greenhouse model: " + greenhouseModel + "\n");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51283/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Sending PUT");
                HttpResponseMessage response = await client.PutAsJsonAsync("api/PlanteWatch/Greenhouse/Put/" + greenhouseId, greenhouseModel);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success!");
                }
            }
        }
    }
}
