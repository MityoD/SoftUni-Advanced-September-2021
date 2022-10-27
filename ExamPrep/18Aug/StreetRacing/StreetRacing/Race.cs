using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
	{
		public Dictionary<string, Car> Participants = new Dictionary<string, Car>();

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }

        public string Name { get; set; }
        
        public string Type { get; set; }
        
        public int Laps { get; set; }
        
        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;
        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate) && Capacity > Count && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        } 
        public bool Remove(string licensePlate)
        {
            return Participants.Remove(licensePlate);
        }
        public Car FindParticipant(string licensePlate)
        {
                return Participants.Values.Where(k => k.LicensePlate == licensePlate).FirstOrDefault();
                        
        }
        public Car GetMostPowerfulCar()
        {
                return Participants.Values.OrderByDescending(p => p.HorsePower).FirstOrDefault();
           
        }
        public string Report()
        {
            StringBuilder sbReport = new StringBuilder();
            sbReport.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in Participants)
            {
                sbReport.AppendLine(item.Value.ToString());
            }
            return sbReport.ToString().TrimEnd();
        }        
    }
}
