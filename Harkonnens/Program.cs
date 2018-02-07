using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Levis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shutdown = false;
            Functions func = new Functions();
            Menus menu = new Menus();
            string dirPath = Directory.GetCurrentDirectory();

            if (File.Exists(dirPath + "\\savedData.txt"))
            {
                func.BootAddVehicle();
            }

            //welcome message
            menu.PrintWelcomeMessage();
            func.KeyToContinue();
            Console.Clear();

            do
            {
                Console.Clear();
                //start of actual program
                menu.PrintMainMenu();

                switch (func.ReadAndTryInt())
                {
                    case 1:
                        func.CarMenu(false);                     
                        break;

                    case 2:
                        func.BoatMenu(false);
                        break;

                    case 3:
                        func.MotorcycleMenu(false);
                        break;

                    case 4:
                        func.PrintAllVehicles();
                        break;

                    case 5:
                        func.SearchForVehicle();
                        break;

                    case 6:
                        shutdown = true;
                        func.VehiclesToString();
                        break;


                    default:
                        break;                    
                }
                
            } while (shutdown == false);
        }
    }
}
