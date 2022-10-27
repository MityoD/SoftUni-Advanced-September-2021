using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients = new List<Ingredient>();

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }
        public bool Remove(string name)
        {
            return Ingredients.Remove(Ingredients.Where(x => x.Name == name).FirstOrDefault());
        }
        public Ingredient FindIngredient(string name)
        {
            return Ingredients.Where(x => x.Name == name).FirstOrDefault();
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }
        public int CurrentAlcoholLevel => CurrentAlcohol();
        public int CurrentAlcohol()
        {
            int totalAlcohol = 0;
            foreach (var item in Ingredients)
            {
                totalAlcohol += item.Alcohol;
            }
            return totalAlcohol;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var item in Ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
