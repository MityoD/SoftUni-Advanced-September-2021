using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        { 
            StringBuilder sb = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            stack.Push(sb.ToString());
            for (int i = 0; i < n; i++)
            {             
                string command = Console.ReadLine();
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "1")
                {
                    sb.Append(commandArgs[1]);
                    stack.Push(sb.ToString());

                }
                else if (commandArgs[0] == "2")
                {
                    int count = int.Parse(commandArgs[1]);
                    sb.Remove(sb.Length - count, count);
                    stack.Push(sb.ToString());
                }
                else if (commandArgs[0] == "3")
                {
                    int index = int.Parse(commandArgs[1]);
                    Console.WriteLine(sb[index-1]);
                }
                else if (commandArgs[0] == "4")
                {
                    stack.Pop();
                    string undo = stack.Peek();
                    sb.Clear();
                    sb.Append(undo);               

                }                
            }
        }
    }
}
