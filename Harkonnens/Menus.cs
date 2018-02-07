using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levis
{
    class Menus
    {       
        //------------------------------Welcome Message------------------------------//
        public void PrintWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello and welcome to the Vehicles app");
            Console.WriteLine();
            Console.WriteLine("Made by: The Harkonnens");
            Console.WriteLine("Planet: Geidi Prime");
            Console.WriteLine();
            Console.WriteLine("\"He who controls the Spice, controls the universe!\" -Baron Harkonnen");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White; 
        }

        //------------------------------Main Menu------------------------------
        public void PrintMainMenu()
        {
            Console.WriteLine("Choose a vehicle you want to print/create/modify");
            Console.WriteLine("\n~ Press 1 for Cars");
            Console.WriteLine("~ Press 2 for Boats");
            Console.WriteLine("~ Press 3 for Motorcycles");
            Console.WriteLine("~ Press 4 to print all vehicles in m/s");
            Console.WriteLine("~ Press 5 to search for vehicles (by name)");
            Console.WriteLine("~ Press 6 to save and exit");
            Console.Write("\nInput: ");
        }

        //------------------------------Vehicle Menu------------------------------//
        public void PrintAddVehicle(string type)
        {
            Console.WriteLine("~ Please enter + to add a {0}", type);
            Console.WriteLine("~ Type 'exit' to go back");
            Console.Write("\nInput: ");
        }

        public void PrintChangeOrAdd(string type)
        {
            Console.WriteLine("~ Please select a " + type + " to change (0-9)");
            Console.WriteLine("~ Enter + to add another " + type);
            Console.WriteLine("~ Type 'exit' to go back");
            Console.Write("\nInput: ");
        }

        public void PrintSetNewSpeedOrRemove(List<IVehicle> currentList, string type, int changeNumb)
        {
            Console.WriteLine("Please set new speed for " + currentList[changeNumb].name + changeNumb + " (0-100) or enter - to remove " + type + ":");
            Console.Write("Input: ");
        }

        //------------------------------------Change Vehicle------------------------------------// 
        public void PrintVehicleSpeedChanged(List<IVehicle> currentList)
        {
            Console.WriteLine(currentList[0].name + " speed was changed!");
            Console.WriteLine("Press a key to go back to main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public void PrintVehicleRemoved(List<IVehicle> currentList)
        {
            Console.WriteLine(currentList[0].name + " removed press any key to go back to main menu \n");
            Console.ReadKey();
            Console.Clear();
            
        }
    }   
}    