using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {

        private readonly List<Car> data;
        public Parking(string type, int capacity)
        {
            data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (Capacity > this.Count)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model) => data.Remove(data.Where(x => x.Manufacturer == manufacturer && x.Model == model).FirstOrDefault());

        public Car GetLatestCar()
        {
            if (data.Count == 0)
            {
                return null;
            }
            return data.OrderByDescending(x => x.Year).First(); // ???
        }




        public Car GetCar(string manufacturer, string model) => data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model); // ???

        public int Count => data.Count;

        public string GetStatistics()
        { StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in data)
            {
            sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        /*
•	
•	
•	Getter Count – returns the number of cars.
•	GetStatistics() – returns a string in the following format:
"The cars are parked in {parking type}:{Car1}{Car2}(…)"*/
    }
}
