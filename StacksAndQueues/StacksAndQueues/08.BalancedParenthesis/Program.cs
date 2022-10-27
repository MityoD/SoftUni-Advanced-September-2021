
using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (var item in input)
            {
                // (, {, and [.
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                }
                else 
                {
                    if (item == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    if (item == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();

                    }
                    if (item == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
