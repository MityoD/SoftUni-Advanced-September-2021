using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int capacity = int.Parse(Console.ReadLine());
            int racks = 0;
            int currentCapacity = capacity;
            while (clothes.Count > 0)
            {
                while ( clothes.Count > 0 && currentCapacity - clothes.Peek() >= 0)
                {                
                    currentCapacity -= clothes.Pop();
                }
                racks++;
                currentCapacity = capacity;
            }
            Console.WriteLine(racks);

        }
    }
}
