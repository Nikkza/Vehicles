using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using FileHandler;
using Parser;

namespace Levis
{
    class Functions
    {
        List<IVehicle> carList = new List<IVehicle>();
        List<IVehicle> boatList = new List<IVehicle>();
        List<IVehicle> mcList = new List<IVehicle>();
        
        Random randomSpeed = new Random();
        Menus menu = new Menus();

        string dirPath = Directory.GetCurrentDirectory();
        string changeOrAdd;
        string changeOrRemove;
        int listCounter;

        public void VehiclesToString()
        {
            List<string> vehicleStrings = new List<string>();

            foreach (var item in carList)
            {
                vehicleStrings.Add(item.GetType().Name + ";" + item.GetSpeed() + ";" + item.GetName());
            }

            foreach (var item in boatList)
            {
                vehicleStrings.Add(item.GetType().Name + ";" + item.GetSpeed() + ";" + item.GetName());
            }

            foreach (var item in mcList)
            {
                vehicleStrings.Add(item.GetType().Name + ";" + item.GetSpeed() + ";" + item.GetName());
            }

            VehicleFileHandler handler = new VehicleFileHandler();
            handler.WriteToFile(vehicleStrings, dirPath);
        }

        public void BootAddVehicle()
        {
                var handler = new VehicleFileHandler();
                var parser = new VehicleParser();

                var parsedList = parser.ParseVehicleString(handler.GetFromFile(dirPath));

                for (int i = 0; i < parsedList.Count(); i += 3)
                {
                    if (parsedList[i] == "Car")
                    {
                        carList.Add(new Car(int.Parse(parsedList[i + 1]), parsedList[i + 2]));
                    }

                    else if (parsedList[i] == "Boat")
                    {
                        boatList.Add(new Boat(int.Parse(parsedList[i + 1]), parsedList[i + 2]));
                    }

                    else if (parsedList[i] == "Motorcycle")
                    {
                        mcList.Add(new Motorcycle(int.Parse(parsedList[i + 1]), parsedList[i + 2]));
                    }
                }
            }
        

        //Method for adding different vehicle types the lists.
        public void AddVehicle(int menuChoice)
        {

            switch (menuChoice)
            {
                case 1:
                    if (carList.Count() < 10)
                    {
                        carList.Add(new Car(RandomNum(), RandomName()));
                        Console.WriteLine("Car created with speed: " + carList[carList.Count()-1].GetSpeed() + carList[carList.Count()-1].GetMetricSpeed());                       
                    }
                    else
                    {
                        Console.WriteLine("Maximum number of cars!");
                    }

                    KeyToMainMenu();                      
                    Console.Clear();
                    break;

                case 2:
                    if (boatList.Count() < 10)
                    {
                        boatList.Add(new Boat(RandomNum(), RandomName()));
                        Console.WriteLine("Boat created with speed: " + boatList[boatList.Count() - 1].GetSpeed() + boatList[boatList.Count() - 1].GetMetricSpeed());
                    }
                    else
                    {
                        Console.WriteLine("Maximum number of boats!");
                    }

                    KeyToMainMenu();
                    Console.Clear();
                    break;

                case 3:
                    if (mcList.Count() < 10)
                    {
                        mcList.Add(new Motorcycle(RandomNum(), RandomName()));
                        Console.WriteLine("Motorcycle created with speed: " + mcList[mcList.Count() - 1].GetSpeed() + mcList[mcList.Count() - 1].GetMetricSpeed());
                    }
                    else
                    {
                        Console.WriteLine("Maximum number of motorcycles!");
                    }

                    KeyToMainMenu();
                    Console.Clear();
                    break;
            }
        }     

        //Prints out total stock of cars and all cars in list.
        public void CarMenu(bool printAll)
        {

            Console.WriteLine("---- " + carList.Count() + " cars in stock! ----");
            listCounter = 0;

            foreach (IVehicle car in carList)
            {
                if (printAll)
                {
                    Console.WriteLine(car.name + listCounter + " ~ " + MetricConversion(car.GetSpeed(), car.GetMetricSpeed()) + " m/s");
                    listCounter++;
                }
                else
                {
                    Console.WriteLine(car.GetType().Name + " " + car.name + listCounter + " ~ " + car.GetSpeed() + " " + car.GetMetricSpeed());
                    listCounter++;
                }
            }
            Console.WriteLine();

            if (!printAll)
            {
                ModifyVehicle(carList, "car");
            }
        }   

        //Prints out total stock of boats and all boats in list.
        public void BoatMenu(bool printAll)
        {
            Console.WriteLine("---- " + boatList.Count() + " boats in stock! ----");
            listCounter = 0;

            foreach (IVehicle boat in boatList)
            {
                if (printAll)
                {
                    Console.WriteLine(boat.name + listCounter + " ~ " + MetricConversion(boat.GetSpeed(), boat.GetMetricSpeed()) + " m/s");
                    listCounter++;
                }
                else
                {
                    Console.WriteLine(boat.name + listCounter + " ~ " + boat.GetSpeed() + " " + boat.GetMetricSpeed());
                    listCounter++;
                }
            }
            Console.WriteLine();

            if (!printAll)
            {
                ModifyVehicle(boatList, "boat");
            }
        }   

        //Prints out total stock of motorcycles and all motorcycles in list.
        public void MotorcycleMenu(bool printAll)
        {
            Console.WriteLine("---- " + mcList.Count() + " motorcycles in stock! ----");
            listCounter = 0;

            foreach (IVehicle mc in mcList)
            {
                if (printAll)
                {
                    Console.WriteLine(mc.name + listCounter + " ~ " + MetricConversion(mc.GetSpeed(), mc.GetMetricSpeed()) + " m/s");
                    listCounter++;
                }
                else
                {
                    Console.WriteLine(mc.name + listCounter + " ~ " + mc.GetSpeed() + " " + mc.GetMetricSpeed());
                    listCounter++;
                }
            }
            Console.WriteLine();

            if (!printAll)
            {
                ModifyVehicle(mcList, "motorcycle");
            }
        } 

        //Prints out all stocks and all vehicles!
        public void PrintAllVehicles()
        {
            CarMenu(true);
            BoatMenu(true);
            MotorcycleMenu(true);
            KeyToMainMenu();
        }  

        //Method for choosing to Modify a vehicle or add a new one.
        public void ModifyVehicle(List<IVehicle> currentList, string type)
        {

            if (currentList.Count == 0)
            {
                menu.PrintAddVehicle(type);
            }
            else
            {
                menu.PrintChangeOrAdd(type);
            }

            do
            {
                int changeNumb;

                changeOrAdd = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (changeOrAdd == "+")
                {
                    if (type == "car")
                        AddVehicle(1);
                    else if (type == "boat")
                        AddVehicle(2);
                    else if (type == "motorcycle")
                        AddVehicle(3);

                    break;
                }
                else if (changeOrAdd == "EXIT")
                    break;

                if (int.TryParse(changeOrAdd, out changeNumb))
                {
                    if (changeNumb < currentList.Count())
                    {
                        menu.PrintSetNewSpeedOrRemove(currentList, type, changeNumb);
                        ChangeSpeedOrRemove(currentList);
                        break;
                    }
                    else
                    {
                        PrintWrongInput();
                    }
                }
                else
                {
                    PrintWrongInput();
                }

            } while (changeOrAdd != "+" || int.Parse(changeOrAdd) >= currentList.Count());
        }   //method for modifying or 

        //Method for Changing speed or to completely remove current vehicle. 
        public void ChangeSpeedOrRemove(List<IVehicle> currentList)
        {
            do
            {
                int newSpeed;

                changeOrRemove = Console.ReadLine();
                Console.WriteLine();

                if (changeOrRemove == "-")
                {
                    menu.PrintVehicleRemoved(currentList);
                    currentList.RemoveAt(int.Parse(changeOrAdd));
                    break;
                }

                else if (int.TryParse(changeOrRemove, out newSpeed))
                {
                    if (newSpeed >= 0 && newSpeed <= 100)
                    {
                        currentList[int.Parse(changeOrAdd)].SetSpeed(newSpeed);
                        menu.PrintVehicleSpeedChanged(currentList);
                        break;
                    }
                    else
                    {
                        PrintWrongInput();
                    }
                }
                else
                {
                    PrintWrongInput();
                }

            } while (changeOrRemove != "-" || int.Parse(changeOrRemove) < 0 || int.Parse(changeOrRemove) > 100);
        }

        //Read and tryParse to see if it´s an INT.
        public int ReadAndTryInt()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                PrintWrongInput();
            }

            Console.WriteLine();
            return result;
        }

        public void KeyToContinue()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
        }

        public void KeyToMainMenu()
        {
            Console.WriteLine("Press a key to go back to main menu...");
            Console.ReadKey();
        }

        public void PrintWrongInput()
        {
            Console.WriteLine("Wrong input! Try again!");
            Console.Write("Input: ");
        }

        //Method for converting all different metrics to m/s.
        public double MetricConversion(int speed, string metricSpeed)
        {
            Convert.ToDouble(speed);
            double newSpeed = 0;

            if (metricSpeed == "km/h")
            {
                newSpeed = speed / 3.6;
            }
            else if (metricSpeed == "knots")
            {
                newSpeed = speed * 0.514444444;
            }
            else if (metricSpeed == "mph")
            {
                newSpeed = speed * 0.44704;
            }

            newSpeed = Math.Round(newSpeed, 2);

            return newSpeed;
        }

        //Generate ranomNums for all Vehicle
        public int RandomNum()
        {
            int rngnumb = new Random().Next(9, 99);
            int Speed = rngnumb;

            return Speed;
        }

        //Generate ranomNames for all Vehicle
        public string RandomName()
        {
            Random rnggud = new Random();
            List<string> names = new List<string>()
            {
                 "Petrus", "Judas", "Taddeus", "Johannes", "Judas",
                "Iskariot", "Matteus", "Tomas", "Jakob","Andreas" ,"Filippos",
                "Jakob2", "Simon","Bartolomaios"

            };
            string name = names[rnggud.Next(names.Count)];
            Thread.Sleep(100);
            return name;
        }

        public void SearchForVehicle()
        {
            Console.Write("Search: ");
            string userInput = Console.ReadLine();

            List<IVehicle> ungroupedList = new List<IVehicle>();

            ungroupedList.AddRange(SearchandPrint.SearchHandler(carList, userInput));
            ungroupedList.AddRange(SearchandPrint.SearchHandler(boatList, userInput));
            ungroupedList.AddRange(SearchandPrint.SearchHandler(mcList, userInput));

            var groupedList = from x in ungroupedList
                        group x by x.GetType();

            if (ungroupedList.Count() == 0)
                Console.WriteLine("Nothing found!");

            else
            {
                Console.Clear();
                Console.WriteLine("Found ({0} vehicles)", ungroupedList.Count());
                
                foreach (var item in groupedList)
                {
                    Console.WriteLine("\n----- " + item.Key.Name + "s -----");
                    Console.WriteLine();

                    foreach (var y in item)
                    {
                        Console.WriteLine(y.GetName() + " ~ " + y.GetSpeed() + " " + y.GetMetricSpeed());
                    }
                }
            }

            Console.WriteLine();
            KeyToMainMenu();
        }
    }
}