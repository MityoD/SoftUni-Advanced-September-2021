using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            string command = "";
            int elementToPrint = 0;

            for (int i = 0; i < N; i++)
            {
                int[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int action = arguments[0];
                if (action == 1)
                {
                    stack.Push(arguments[1]);
                }
                else if (action == 2)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    stack.Pop();
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else if (action == 3)
                    {
                        elementToPrint = int.MinValue;
                        foreach (var item in stack)
                        {
                            if (item > elementToPrint)
                            {
                                elementToPrint = item;
                            }
                        }
                    }
                    else
                    {
                        elementToPrint = int.MaxValue;
                        foreach (var item in stack)
                        {
                            if (item < elementToPrint)
                            {
                                elementToPrint = item;
                            }
                        }
                    }
                    Console.WriteLine(elementToPrint);
                    elementToPrint = 0;
                }
            }
            Console.WriteLine(string.Join(", ", stack));            
        }
    }
}
