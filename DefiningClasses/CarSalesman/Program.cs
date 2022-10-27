using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement = 0;
                string efficiency = "n/a";
                if (input.Length == 3)
                {
                    if (Int32.TryParse(input[2], out int result))
                    {
                        displacement = result;
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }
                if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    efficiency = input[3];
                }
                Engine newEngine = new Engine(model, power, displacement, efficiency);
                engines.Add(newEngine);
            }
            int M = int.Parse(Console.ReadLine());
            List<Car> newCars = new List<Car>();
            for (int i = 0; i < M; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string currentEngineModel = input[1];
                int weight = 0;
                string color = "n/a";

                if (input.Length == 3)
                { 
                    if (Int32.TryParse(input[2], out int result))
                    {
                        weight = result;
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                Engine engine = engines.Where(n => n.Model == currentEngineModel).FirstOrDefault();
                Car currentCar = new Car(model, engine, weight, color);
                newCars.Add(currentCar);
            }
            foreach (var car in newCars)
            {
                Console.WriteLine(car.ToString());               
            }
        }
    }
}
