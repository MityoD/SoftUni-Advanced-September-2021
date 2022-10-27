using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int[]> pumpInfo = new Queue<int[]>();
            for (int i = 0; i < N; i++)
            {
                pumpInfo.Enqueue(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }
            int counter = 0;
            while (true)
            {
            int petrolLeft = 0;
                foreach (var item in pumpInfo)
                {
                    int currentPetrol = item[0];
                    int distance = item[1];
                    petrolLeft += currentPetrol;
                    petrolLeft -= distance;
                    if (petrolLeft < 0)
                    {
                        int[] element = pumpInfo.Dequeue();
                        pumpInfo.Enqueue(element);
                        counter++;
                        break;
                    }
                }
                if (petrolLeft > 0)
                {
                    Console.WriteLine(counter);
                    break;
                }
            }
            
        }
    }
}
