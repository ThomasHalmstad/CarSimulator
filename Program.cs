using CarSimulator.Domain;
using System;
using System.Threading;
using static System.Console;

namespace CarSimulator
{
    class Program
    {
        static Car[] carList = new Car[10];

        static void Main(string[] args)
        {
            uint carListCurrentIndexPosition = 0;

            bool shouldNotExit = true;

            while (shouldNotExit)
            {
                WriteLine("1. Add car");
                WriteLine("2. List cars");
                WriteLine("3. Change registration number");
                WriteLine("4. Simulate speed");
                WriteLine("5. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        Write("Brand: ");

                        string brand = ReadLine();

                        Write("Model: ");

                        string model = ReadLine();

                        Write("Registration number: ");

                        string registrationNumber = ReadLine();

                        Car newCar = new Car(brand, model, registrationNumber);

                        carList[carListCurrentIndexPosition++] = newCar; 

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        Write("Brand".PadRight(15, ' '));
                        Write("Model".PadRight(15, ' '));
                        WriteLine("RegistrationNumber");
                        WriteLine("--------------------------------------------------");

                        foreach (Car car in carList)
                        {
                            if (car == null) continue;

                            Write($"{car.Brand}".PadRight(15, ' '));
                            Write($"{car.Model}".PadRight(15, ' '));
                            WriteLine($"{car.RegistrationNumber}");
                        }

                        WriteLine("");
                        WriteLine("<Press any key to continue>");

                        ReadKey(true);

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:


                        Write("Current registration number: ");

                        string currentRegistrationNumber = ReadLine();

                        Write("New registration number: ");

                        string  newRegistrationNumber = ReadLine();

                        Car theCar = SearchCarByRegistrationNumber(currentRegistrationNumber);

                        if (theCar != null)
                        {
                            theCar.RegistrationNumber = newRegistrationNumber;

                            WriteLine("Successfully registered new registration number");

                            Thread.Sleep(2000);
                        }
                        else
                        {
                            WriteLine("Car not found");

                            Thread.Sleep(2000);
                        }

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:

                        shouldNotExit = false;

                        break;
                }

                Clear();
            }

        }

        public static Car SearchCarByRegistrationNumber(string currentRegistrationNumber)
        {
            Car carReferenceToReturn = null;

            foreach (Car car in carList)
            {
                if (car == null) continue;

                if (car.RegistrationNumber == currentRegistrationNumber)
                {
                    carReferenceToReturn = car;

                    break;
                }
            }

            return carReferenceToReturn;
        }
    }
}
