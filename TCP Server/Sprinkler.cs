using System;
using RestApi.Controllers;
using System.Threading;
using ModelLib.Model;

namespace TCP_Server
{
    public class Sprinkler
    {
        //Instance of PlanteModel to be tested
        private static PlanteWatchController _planteWatchController = new PlanteWatchController();

        //When a greenhouse exceeds 25 degrees, this function will lower it's temperature by 1 degree every minute,
        //pretending to be a sprinkler.
        public static void SprinklerStart(int greenhouseTemperature, int greenhouseId)
        {

            for (int i = greenhouseTemperature; i > 25; i--)
                
            {

                GreenhouseModel greenhouseModel = new GreenhouseModel();
                greenhouseModel = (GreenhouseModel) _planteWatchController.GetGreenhouseById(greenhouseId);

                Console.WriteLine(_planteWatchController.GetGreenhouseById(greenhouseId).ToString());

                Console.WriteLine("Greenhouse Model: " + greenhouseModel);
                Console.WriteLine("Greenhouse Id: " + greenhouseId);

                Console.WriteLine("Starting sprinkler round");
                _planteWatchController.PutGreenhouse(greenhouseId, greenhouseModel);
                Thread.Sleep(6000);
                Console.WriteLine("Finished sprinkler round");
            }
            
        }
    }
}
