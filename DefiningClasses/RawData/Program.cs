using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Engine newEngine = new Engine(engineSpeed, enginePower);
                Cargo newCargo = new Cargo(cargoType, cargoWeight);
                List<Tire> tires = new List<Tire>();
                for (int tireIndex = 5; tireIndex < input.Length; tireIndex += 2)
                {
                    double tirePressure = double.Parse(input[tireIndex]);
                    int tireAge = int.Parse(input[tireIndex + 1]);
                    Tire newTire = new Tire(tirePressure, tireAge);
                    tires.Add(newTire);
                }
                Car newCar = new Car(model, newEngine , newCargo, tires);
                cars.Add(newCar);
            }
            string data = Console.ReadLine();

            if (data == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == data))
                {
                    if (car.Tires.Any(p => p.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == data))
                {
                    if (car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
