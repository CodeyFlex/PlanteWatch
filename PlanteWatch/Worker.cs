using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ModelLib.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace PlanteWatch
{
    class Worker
    {
        private static Token token = new Token();
        private static string GetPlantURI = "https://trefle.io/api/v1/plants?token=" + token.TokenValue + "&filter[common_name]=Orchardgrass";
        //private static string GetPlantURI = "http://localhost:51283/api/PlanteWatch/Trefle";

        public async void Start()
        {
            
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                string response = client.DownloadString(GetPlantURI);
                Console.WriteLine(response);
            }

            /* for at gemme foreach struktur
            TrefleModel plantList = new TrefleModel();
            plantList = (TrefleModel)await GetPlantsAsync();
            foreach (var plants in plantList.Data)
            {
                Console.WriteLine(plants.data.ToString());
            }*/

            /*
            TrefleModel plantList = new TrefleModel();
            plantList = (TrefleModel)await GetOnePlantAsync();
            
            Console.WriteLine(plantList.Data.ToString());*/

        }
        /*
        public static async Task<IList<TrefleModel>> GetPlantsAsync()
        {
            Console.WriteLine("Get All Plant Data:\n");

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(GetPlantURI);
                IList<TrefleModel> cList = JsonConvert.DeserializeObject<IList<TrefleModel>>(content);
                return cList;
            }
        }

        public static async Task<TrefleModel> GetOnePlantAsync()
        {
            Console.WriteLine("Get All Plant Data:\n");

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(GetPlantURI);
                TrefleModel cList = JsonConvert.DeserializeObject<TrefleModel>(content);
                return cList;
            }
        }*/
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    }
}