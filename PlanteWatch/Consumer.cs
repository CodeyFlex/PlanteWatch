using System;
using ModelLib.Model;
using RestApi.Controllers;

namespace PlanteWatch
{
    public class Consumer
    {
        //Instance of RestAPI Controller
        private static PlanteWatchController _planteWatchController = new PlanteWatchController();

        private static bool _running = true;
        private static string _input = null;
        private static string _mainMenu = "Which data do you need?\n1: All\n2: Humidity\n3: End";

        static void ErrorMessage()
        {
            Console.WriteLine("Unrecognisable command");
        }

        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("\n" + _mainMenu);
                _input = Console.ReadLine();

                //All input
                if (_input == "All" | _input == "1")
                {
                    foreach (var array in _planteWatchController.Get())
                    {
                        Console.WriteLine(array);
                    }
                }

                //Humidity input
                else if (_input == "Humidity" | _input == "2")
                {
                    foreach (var planteModel in _planteWatchController.Get())
                    {
                        Console.WriteLine(planteModel.Id + planteModel.Humidity);
                    }
                }

                //End input
                else if (_input == "End" | _input == "3")
                {
                    _running = false;
                }

                //Unrecognisable input
                else if (_input != "All" && _input != "1" && _input != "Humidity" && _input != "2" && _input != "End" && _input != "3")
                {
                    ErrorMessage();
                }
            } while (_running == true);
        }
    }
}
