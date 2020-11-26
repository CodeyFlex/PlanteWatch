using System;
using ModelLib.Model;
using RestApi.Controllers;

namespace PlanteWatch
{
    public class Consumer
    {
        //Instance of RestAPI Controller
        private static PlanteWatchController _planteWatchController = new PlanteWatchController();

        private static bool _runningBool = true;
        private static bool _plantMenuBool;
        private static bool _greenhouseMenuBool;
        private static string _input;
        private static string _mainMenuString = "Which data do you need?\n1: Plants\n2: Grenhouses\n3: End";
        private static string _plantMenuString = "Which Plant data do you need?\n1: All\n2: Humidity\n3: Nourishment\n4: Back";
        private static string _greenhouseMenuString = "Which Greenhouse data do you need?\n1: All\n2: Humidity\n3: Temperature\n4: Light Level\n5: Back";

        static void ErrorMessage()
        {
            Console.WriteLine("Unrecognisable command");
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n" + _mainMenuString);
                _input = Console.ReadLine();
                Console.Clear();

                //Plants input
                if (_input == "Plants" | _input == "1")
                {
                    _plantMenuBool = true;
                    PresentPlantMenu();
                }

                //Greenhouse input
                if (_input == "Greenhouses" | _input == "2")
                {
                    _greenhouseMenuBool = true;
                    PresentGreenhouseMenu();
                }

                //End input
                else if (_input == "End" | _input == "3")
                {
                    _runningBool = false;
                }

                //Unrecognisable input
                else if (_input != "Plants" && _input != "1" && _input != "Greenhouses" && _input != "2" &&
                         _input != "End" && _input != "3")
                {
                    ErrorMessage();
                }
            }while (_runningBool == true);
        }

        //Plants Menu
        static void PresentPlantMenu()
        {
            do
            {
                Console.WriteLine("\n" + _plantMenuString);
                _input = Console.ReadLine();
                Console.Clear();

                //All input
                if (_input == "All" | _input == "1")
                {
                    Console.WriteLine("All Plant Data: \n");

                    foreach (var array in _planteWatchController.GetPlants())
                    {
                        Console.WriteLine(array);
                    }
                }

                //Humidity input
                else if (_input == "Humidity" | _input == "2")
                {
                    Console.WriteLine("All Plant Humidity Data: \n");

                    foreach (var planteModel in _planteWatchController.GetPlants())
                    {
                        Console.Write("Name: " + planteModel.Name);
                        Console.Write(" Humidity: " + planteModel.Humidity + "\n");
                    }
                }

                //Nourishment input
                else if (_input == "Nourishment" | _input == "3")
                {
                    Console.WriteLine("All Plant Nourishment Data: \n");

                    foreach (var planteModel in _planteWatchController.GetPlants())
                    {
                        Console.Write("Name: " + planteModel.Name);
                        Console.Write(" Nourishment: " + planteModel.Nutrition + "\n");
                    }
                }

                //Back input
                else if (_input == "Back" | _input == "4")
                {
                    _plantMenuBool = false;
                }

                //Unrecognisable input
                else if (_input != "All" && _input != "1" && _input != "Humidity" && _input != "2" &&
                         _input != "Back" && _input != "4" && _input != "Nourishment" && _input != "3")
                {
                    ErrorMessage();
                }
            } while (_plantMenuBool == true);
        }

        //Greenhouse Menu
        static void PresentGreenhouseMenu()
        {
            do
            {
                Console.WriteLine("\n" + _greenhouseMenuString);
                _input = Console.ReadLine();
                Console.Clear();

                //All input
                if (_input == "All" | _input == "1")
                {
                    Console.WriteLine("All Greenhouse Data: \n");

                    foreach (var array in _planteWatchController.GetGreenhouses())
                    {
                        Console.WriteLine(array);
                    }
                }

                //Humidity input
                else if (_input == "Humidity" | _input == "2")
                {
                    Console.WriteLine("All Greenhouse Humidity Data: \n");

                    foreach (var greenhouseModel in _planteWatchController.GetGreenhouses())
                    {
                        Console.Write("Name: " + greenhouseModel.Name);
                        Console.Write(" Humidity: " + greenhouseModel.Humidity + "\n");
                    }
                }

                //Nourishment input
                else if (_input == "Temperature" | _input == "3")
                {
                    Console.WriteLine("All Greenhouse Temperature Data: \n");

                    foreach (var greenhouseModel in _planteWatchController.GetGreenhouses())
                    {
                        Console.Write("Name: " + greenhouseModel.Name);
                        Console.Write(" Temperature: " + greenhouseModel.Temperature + "\n");
                    }
                }

                //Light Level input
                else if (_input == "Light Level" | _input == "4")
                {
                    Console.WriteLine("All Greenhouse Light Level Data: \n");

                    foreach (var greenhouseModel in _planteWatchController.GetGreenhouses())
                    {
                        Console.Write("Name: " + greenhouseModel.Name);
                        Console.Write(" Light Level: " + greenhouseModel.LightLevel + "\n");
                    }
                }

                //Back input
                else if (_input == "Back" | _input == "5")
                {
                    _greenhouseMenuBool = false;
                }

                //Unrecognisable input
                else if (_input != "All" && _input != "1" && _input != "Humidity" && _input != "2" &&
                         _input != "Temperature" && _input != "3" && _input != "Light Level" && _input != "4" &&
                        _input != "Back" | _input != "5")
                {
                    ErrorMessage();
                }
            } while (_greenhouseMenuBool == true);
        }
    }
}
