using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }
        public IReadOnlyCollection<Drone> Drones => drones.AsReadOnly();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15) //<=?
            {
                return "Invalid drone.";
            }

            if (this.Capacity > this.Count)
            {
                drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
            else
            {
                return "Airfield is full.";
            }
        }

        public bool RemoveDrone(string name) => drones.Remove(Drones.Where(x => x.Name == name).FirstOrDefault());

        public int RemoveDroneByBrand(string brand)
        {
            List<Drone> dronesToRemove = Drones.Where(x => x.Brand == brand).ToList();
            int returnValue = dronesToRemove.Count;
            if (returnValue == 0)
            {
                return 0;
            }
            else
            {
                foreach (var item in dronesToRemove)
                {
                    drones.Remove(item);
                }
                return returnValue;
            }
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(x => x.Name == name);

            if (drone == null)
            {
                return null;
            }

            drone.Available = false;

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = this.Drones.Where(x => x.Range >= range).ToList();
           
                foreach (var item in dronesToFly)
                {
                    FlyDrone(item.Name);
                }
            return dronesToFly;
          
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var drone in Drones.Where(x => x.Available == true))
            {
            sb.AppendLine(drone.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
