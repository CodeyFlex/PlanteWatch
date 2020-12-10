using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib.Model;
using Newtonsoft.Json;

namespace TCP_Server
{
    public class Worker
    {
        private static String _uri = "http://localhost:51283/api/PlanteWatch/Greenhouses/Temperature/25";
        public static async void Start()
        {
            List<GreenhouseModel> greenhouseList = new List<GreenhouseModel>();
            greenhouseList = (List<GreenhouseModel>)await GetAllGreenhousesAsync();
            foreach (var greenhouses in greenhouseList)
            {
                Console.WriteLine("for each before");
                Console.WriteLine(greenhouses.Temperature + greenhouses.Id);
                Sprinkler.SprinklerStart(greenhouses.Temperature, greenhouses.Id);
                Console.WriteLine("for each");
            }
        }

        public static async Task<IList<GreenhouseModel>> GetAllGreenhousesAsync()
        {
            Console.WriteLine("Get All Greenhouse with temperature above 25:\n");
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(_uri);
                IList<GreenhouseModel> cList = JsonConvert.DeserializeObject<IList<GreenhouseModel>>(content);
                return cList;

            }
        }
    }
}
