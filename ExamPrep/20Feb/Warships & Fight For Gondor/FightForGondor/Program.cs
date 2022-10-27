using System;
using System.Collections.Generic;
using System.Linq;

namespace FightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastOrc = 0;
            int lastPlate = 0;
            int orcsWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> orcs = new Stack<int>();
            int currentPlate = 0;
            int currentOrc = 0;
            for (int i = 1; i <= orcsWaves; i++)
            {
                orcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }
                while (orcs.Count > 0 && plates.Count > 0)
                {
                        currentOrc = orcs.Peek();
                        currentPlate = plates.Peek();
                    if (currentOrc > currentPlate)
                    {
                        int toSwap = currentOrc - currentPlate;
                        currentPlate = 0;
                        orcs.Pop();
                        orcs.Push(toSwap);
                        plates.Dequeue();
                    }
                    else if (currentPlate > currentOrc)
                    {
                        orcs.Pop();
                        currentPlate -= currentOrc;
                        plates.Dequeue();
                        plates.Enqueue(currentPlate);

                        for (int j = 0; j < plates.Count - 1; j++)
                        {
                            int currentValue = plates.Dequeue();
                            plates.Enqueue(currentValue);
                        }
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }

                }
                if (plates.Count == 0)
                {
                    break;
                }
            }
            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: " + string.Join(", ", plates));
            }
            else if (orcs.Count > 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: " + string.Join(", ", orcs));
            }
        }
    }
}
