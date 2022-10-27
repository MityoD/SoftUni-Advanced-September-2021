using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {   
            int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> firstLine = new HashSet<int>();
            HashSet<int> secondLine = new HashSet<int>();
            for (int i = 0; i < items[0]; i++)
            {
                firstLine.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < items[1]; i++)
            {
                secondLine.Add(int.Parse(Console.ReadLine()));
            }
            foreach (var firstItem in firstLine)
            {
                foreach (var secondItem in secondLine)
                {
                    if (firstItem == secondItem)
                    {
                        Console.Write($"{firstItem} ");
                    }
                }
            }
            
        }
    }
}
