using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            /*	•	On the first line you will receive the tasks, separated by ", ".
	•	On the second line you will the threads, separated by a single space.
	•	On the third line, you will receive a single integer – value of the task to be killed.
*/

            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int taskToKillValue = int.Parse(Console.ReadLine());

            int currentTask = 0;
            int currentThread = 0;

            while (true)
            {
                currentTask = tasks.Peek();
                currentThread = threads.Peek();
                if (currentTask == taskToKillValue)
                {
                    break;
                }
                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {currentThread} killed task {taskToKillValue}");
            Console.WriteLine(string.Join(" ", threads.ToArray()));
        }
    }
}
