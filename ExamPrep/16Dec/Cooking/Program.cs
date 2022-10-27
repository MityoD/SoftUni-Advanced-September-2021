using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int[]> foods = new Dictionary<string, int[]>();
            foods.Add("Bread", new int[] { 25, 0 });
            foods.Add("Cake", new int[] { 50, 0 });
            foods.Add("Pastry", new int[] { 75, 0 });
            foods.Add("Fruit Pie", new int[] { 100, 0 });
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                bool foodCooked = false;
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Peek();
                int sum = liquid + ingredient;
                foreach (var food in foods)
                {
                    if (sum == food.Value[0])
                    {
                        ingredients.Pop();

                        foods[food.Key][1] += 1;
                        foodCooked = true;
                        break;
                    }
                }
                if (!foodCooked)
                {
                    int newIngredient = ingredients.Pop() + 3;
                    ingredients.Push(newIngredient);

                }
            }
            bool allFoods = true;
            foreach (var food in foods)
            {
                if (food.Value[1] == 0)
                {
                    Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
                    allFoods = false;
                    break;
                }

            }
            if (allFoods)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
           
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var food in foods.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value[1]}");
            }
        }
    }
}
