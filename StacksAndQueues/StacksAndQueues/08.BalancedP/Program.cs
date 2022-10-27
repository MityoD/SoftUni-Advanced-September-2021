
using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isBalanced = true;
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
                    if (stack.Count== 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    if (item == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else if (item == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();

                    }
                    else if (item == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        isBalanced = false;
                    }
                }
            }

            if (isBalanced)
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
