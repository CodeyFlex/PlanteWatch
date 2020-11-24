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

        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine(_mainMenu);
                _input = Console.ReadLine();

                //All input
                if (_input == "All" | _input == "1")
                {
                    foreach (var array in _planteWatchController.Get())
                    {
                        Console.WriteLine(array);
                    }
                    Console.WriteLine(_mainMenu);
                    _input = Console.ReadLine();
                }

                //Humidity input
                if (_input == "Humidity" | _input == "2")
                {
                    foreach (PlanteModel planteModel in _planteWatchController.Get())
                    {
                        Console.WriteLine(planteModel.Humidity);
                    }
                    Console.WriteLine(_mainMenu);
                    _input = Console.ReadLine();
                }

                //End input
                if (_input == "End" | _input == "3")
                {
                    _running = false;
                }

                //Unrecognisable input
                else
                {
                    Console.WriteLine("Unrecognisable command");
                    _input = Console.ReadLine();
                }
            } while (_running == true);
        }
    }
}
