using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            List<int> sets = new List<int>();
            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();
                if (currentHat > currentScarf)
                {
                    int currentSet = currentHat + currentScarf;
                    sets.Add(currentSet);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentScarf > currentHat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    int hatValue = hats.Pop();
                    hats.Push(hatValue + 1);
                }               
            }
            Console.WriteLine($"The most expensive set is: {sets.OrderByDescending(x => x).FirstOrDefault()}");
            Console.WriteLine(string.Join(" ", sets));           
        }
    }
}
