using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            /*4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress*/
            for (int i = 0; i < n; i++)
            {
                string[] colorWithItems = Console.ReadLine().Split(" -> ");
                string color = colorWithItems[0];
                string[] items = colorWithItems[1].Split(',');
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < items.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(items[j]))
                    {
                        wardrobe[color].Add(items[j], 0);
                    }
                    wardrobe[color][items[j]]++;
                }
            }
            string[] lookFor = Console.ReadLine().Split();
            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (clothe, count) in clothes)
                {
                    if (color == lookFor[0] && clothe == lookFor[1])
                    {
                        Console.WriteLine($"* {clothe} - {count} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {clothe} - {count}");
                }
            }
        }
    }
}
