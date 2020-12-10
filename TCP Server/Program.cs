using RestApi.Controllers;
using System;
using System.Linq;
using System.Threading;

namespace TCP_Server
{
    class Program
    {

        //Instance of PlanteModel to be tested
        private static PlanteWatchController _planteWatchController = new PlanteWatchController();

        private string _uri;

        static void Main(string[] args)
        {
            /*
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 25558);
            listener.Start();

            Console.WriteLine("Waiting for a connection.");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted.");

            NetworkStream stream = client.GetStream();
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());
            */


            while (true)
            {
                if (_planteWatchController.GetGreenhousesByTemperature(10).Count() >= 1)
                {
                    Console.WriteLine("Successfully executed Start Sprinkler!");
                    Worker.Start();
                }
                else
                {
                    Console.WriteLine("Failed to execute Start Sprinkler!");
                    Console.WriteLine(_planteWatchController.GetGreenhousesByTemperature(25).Count());
                }
                Thread.Sleep(6000);
            }
        }
    }
}
