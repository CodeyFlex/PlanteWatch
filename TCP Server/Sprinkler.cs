using System;
using System.Net.Http;
using System.Net.Http.Headers;
using RestApi.Controllers;
using System.Threading;
using ModelLib.Model;

namespace TCP_Server
{
    public class Sprinkler
    {
        //Instance of PlanteWatchController
        private static PlanteWatchController _planteWatchController = new PlanteWatchController();

        //When a greenhouse exceeds 25 degrees, this function will lower it's temperature by 1 degree every minute,
        //pretending to be a sprinkler.
        public static async void SprinklerStart(int greenhouseTemperature, int greenhouseId)
        {
            Thread.Sleep(6000);
                GreenhouseModel greenhouseModel = new GreenhouseModel();
                greenhouseModel = (GreenhouseModel) _planteWatchController.GetGreenhouseById(greenhouseId);

                Console.WriteLine(_planteWatchController.GetGreenhouseById(greenhouseId).ToString());

                Console.WriteLine("Greenhouse Model: " + greenhouseModel);
                Console.WriteLine("Greenhouse Id: " + greenhouseId);

                Console.WriteLine("Starting sprinkler round\n");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51283/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Console.WriteLine("Sending PUT\n");
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/PlanteWatch/Greenhouse/Put/" + greenhouseId, greenhouseModel);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Success!\n");
                    }
            }
            Console.WriteLine("Finished sprinkler round\n");
        }
    }
}