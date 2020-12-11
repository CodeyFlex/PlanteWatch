using ModelLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TCP_Server
{
    public class Worker
    {
        //Instance of StatusGetter
        private static StatusGetter _statusGetter = new StatusGetter();

        private static String _uriGetGreenhousesByTemperature = "http://localhost:51283/api/PlanteWatch/Greenhouses/Temperature/25";
        private static String _uriGetAllPlants = "http://localhost:51283/api/PlanteWatch/Plants/";

        public static async void StartGreenhouseTemperatureAdjuster()
        {
            List<GreenhouseModel> greenhouseList = new List<GreenhouseModel>();
            greenhouseList = (List<GreenhouseModel>)await GetAllGreenhousesWithTemperatureAsync();
            foreach (var greenhouses in greenhouseList)
            {
                Console.WriteLine("for each before");
                Console.WriteLine(greenhouses.Temperature + greenhouses.Id);
                Sprinkler.SprinklerStart(greenhouses.Temperature, greenhouses.Id);
                Console.WriteLine("for each");
            }
        }

        public static async Task<IList<GreenhouseModel>> GetAllGreenhousesWithTemperatureAsync()
        {
            Console.WriteLine("Get All Greenhouse with temperature above 25:\n");
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(_uriGetGreenhousesByTemperature);
                IList<GreenhouseModel> cList = JsonConvert.DeserializeObject<IList<GreenhouseModel>>(content);
                return cList;

            }
        }

        //Gets the status of plants and updates it
        public static async void StartPlantStatusGetter()
        {
            List<PlanteModel> plantList = new List<PlanteModel>();
            plantList = (List<PlanteModel>)await GetAllPlantsAsync();
            foreach (var plants in plantList)
            {
                Console.WriteLine(plants);
                _statusGetter.GetPlantValues(plants.Id, plants.Name, plants.Humidity, plants.Nutrition);
            }
        }

        public static async Task<IList<PlanteModel>> GetAllPlantsAsync()
        {
            Console.WriteLine("Get All Plants Status:\n");
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(_uriGetAllPlants);
                IList<PlanteModel> cList = JsonConvert.DeserializeObject<IList<PlanteModel>>(content);
                return cList;
            }
        }

        //Gets the status of greenhouses and updates it
        public static async void StartGreenhouseStatusGetter()
        {
            List<GreenhouseModel> greenhouseList = new List<GreenhouseModel>();
            greenhouseList = (List<GreenhouseModel>)await GetAllGreenhousesAsync();
            foreach (var greenhouses in greenhouseList)
            {
                Console.WriteLine(greenhouses);
                _statusGetter.GetGreenhouseValues(greenhouses.Id, greenhouses.Name, greenhouses.Humidity, greenhouses.Temperature, greenhouses.LightLevel);
            }
        }

        public static async Task<IList<GreenhouseModel>> GetAllGreenhousesAsync()
        {
            Console.WriteLine("Get All Greenhouses Status:\n");
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(_uriGetAllPlants);
                IList<GreenhouseModel> cList = JsonConvert.DeserializeObject<IList<GreenhouseModel>>(content);
                return cList;
            }
        }
    }
}
