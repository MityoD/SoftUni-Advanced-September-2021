using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsQueue = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            string command = Console.ReadLine();
            while (true)
            {
                
                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command.Contains("Add"))
                { string songToAdd = command.Substring(4);
                    if (!songsQueue.Contains(songToAdd))
                    {
                        songsQueue.Enqueue(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
                if (songsQueue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    Environment.Exit(0);
                }
                command = Console.ReadLine();
            }            
        }
    }
}
