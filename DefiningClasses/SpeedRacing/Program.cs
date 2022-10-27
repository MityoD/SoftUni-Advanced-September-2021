using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                Car newCar = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(newCar);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArgs = command.Split();
                string carModel = commandArgs[1];
                double amountOfKm = double.Parse(commandArgs[2]);
                foreach (var car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.DriveCar(amountOfKm);
                        continue;
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
