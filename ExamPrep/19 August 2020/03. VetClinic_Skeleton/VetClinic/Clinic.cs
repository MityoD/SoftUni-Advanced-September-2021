using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly List<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            pets = new List<Pet>();
        }
        public int Count => pets.Count;
        public int Capacity { get; set; }
        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                pets.Add(pet);
            }
        }
        public bool Remove(string name) => pets.Remove(pets.FirstOrDefault(x => x.Name == name));

        public Pet GetPet(string name, string owner) => pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        public Pet GetOldestPet() => pets.OrderByDescending(x => x.Age).First();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in pets)
            {
            sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
        /*	•
	•	GetStatistics() – returns a string in the following format:
		o	"The clinic has the following patients:Pet {Name} with owner: {Owner}Pet {Name} with owner: {Owner}
   (…)"
*/
    }
}
