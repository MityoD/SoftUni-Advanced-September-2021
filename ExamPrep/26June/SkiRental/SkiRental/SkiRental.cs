using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }
      
        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model) 
        {
            return data.Remove(data.Where(x => x.Manufacturer == manufacturer).Where(m => m.Model == model).FirstOrDefault());
        }
        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return data.Where(x => x.Manufacturer == manufacturer).Where(m => m.Model == model).FirstOrDefault();
        }
        
        public int Count => data.Count;       

        public string GetStatistics()
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                statistics.AppendLine(item.ToString());
            }
            return statistics.ToString().TrimEnd();
        }
    }
}
