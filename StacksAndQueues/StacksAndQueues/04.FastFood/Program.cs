using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());
            int[] toServe = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(toServe);
            int maxOrder = int.MinValue;
            foreach (var item in orders)
            {
                if (item > maxOrder)
                {
                    maxOrder = item;
                }
            }
            Console.WriteLine(maxOrder);
            while (totalFood > 0 && orders.Count > 0 && totalFood >= orders.Peek())
            {
                
                totalFood -= orders.Dequeue();
                
            }
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
