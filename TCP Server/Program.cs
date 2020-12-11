using RestApi.Controllers;
using System;
using System.Linq;
using System.Threading;

namespace TCP_Server
{
    class Program
    {
        //Instance of PlanteWatchController
        private static PlanteWatchController _planteWatchController = new PlanteWatchController();

        static void Main(string[] args)
        {
            /*
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 25558);
            listener.StartGreenhouseTemperatureAdjuster();

            Console.WriteLine("Waiting for a connection.");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted.");

            NetworkStream stream = client.GetStream();
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            */


            while (true)
            {
                Console.WriteLine("Getting status of plants and greenhouses: ");
                
                Worker.StartPlantStatusGetter();
                Worker.StartGreenhouseStatusGetter();
                
                if (_planteWatchController.GetGreenhousesByTemperature(25).Count() >= 1)
                {
                    Console.WriteLine("Successfully executed StartGreenhouseTemperatureAdjuster Sprinkler!");
                    Worker.StartGreenhouseTemperatureAdjuster();
                }
                else
                {
                    Console.WriteLine("Failed to execute StartGreenhouseTemperatureAdjuster Sprinkler!");
                    Console.WriteLine(_planteWatchController.GetGreenhousesByTemperature(25).Count());
                }
                Thread.Sleep(6000);
            }
        }
    }
}
