using System;
using System.Net;

namespace PlanteWatch
{
    class Worker
    {
        //private static string GetPlantURI = "http://localhost:51283/api/PlanteWatch/Trefle";

        public async void Start(string token)
        {
            
            using (var client = new WebClient())
            {
                string GetPlantURI = "https://trefle.io/api/v1/plants?token=" + token + "&filter[common_name]=Orchardgrass";

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