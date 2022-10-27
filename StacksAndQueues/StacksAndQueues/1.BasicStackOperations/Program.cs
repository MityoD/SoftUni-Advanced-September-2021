using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] commands = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] stackNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int numbersToPush = commands[0];
            int numbersToPop = commands[1];
            int numberToLook = commands[2];

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numbersToPush; i++)
            {
                numbers.Push(stackNumbers[i]);
            }
            for (int i = 0; i < numbersToPop; i++)
            {
                numbers.Pop();
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("0");
                Environment.Exit(0);                
            }
            foreach (var item in numbers)
            {
                if (item == numberToLook)
                {
                    Console.WriteLine("true");
                    Environment.Exit(0);
                }
            }
            int smallestElement = int.MaxValue;
            foreach (var item in numbers)
            {
                if (item < smallestElement)
                {
                    smallestElement = item;
                }
            }
            Console.WriteLine(smallestElement);
            
        }
    }
}
