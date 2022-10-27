using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbolsCount = new SortedDictionary<char, int>();
            foreach (var symbol in input)
            {
                if (!symbolsCount.ContainsKey(symbol))
                {
                    symbolsCount.Add(symbol, 0);
                }
                symbolsCount[symbol]++;
            }
            foreach (var item in symbolsCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
