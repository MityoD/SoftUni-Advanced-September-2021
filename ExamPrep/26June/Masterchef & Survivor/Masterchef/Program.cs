using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            //first ingredient value and the last freshness level value
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int[]> dishes = new Dictionary<string, int[]>();
            dishes.Add("Dipping sauce", new int[] { 150, 0 });
            dishes.Add("Green salad", new int[] { 250, 0 });
            dishes.Add("Chocolate cake", new int[] { 300, 0 });
            dishes.Add("Lobster", new int[] { 400, 0 });
            while (ingredients.Count > 0 && freshnessLevel.Count > 0)
            {
                bool dishMade = false;
                int currentIngredient = ingredients.Peek();
                int currentFreshnessLevel = freshnessLevel.Peek();
                if (currentIngredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int totalFreshnessLevel = currentFreshnessLevel * currentIngredient;
                foreach (var item in dishes)
                {
                    if (item.Value[0] == totalFreshnessLevel)
                    {
                        item.Value[1]++;
                        ingredients.Dequeue();
                        freshnessLevel.Pop();
                        dishMade = true;
                    }
                }
                if (!dishMade)
                {
                freshnessLevel.Pop();
                currentIngredient += 5;
                ingredients.Dequeue();
                ingredients.Enqueue(currentIngredient);
                }
            }
            if (dishes.Values.All(x => x[1] > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var item in dishes.OrderBy(x => x.Key))
            {
                if (item.Value[1] > 0)
                {
                    Console.WriteLine($"# {item.Key} --> {item.Value[1]}");
                }
            }
        }
    }
}
