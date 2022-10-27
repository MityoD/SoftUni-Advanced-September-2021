using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int waste = 0;
            while (guests.Count > 0 && plates.Count > 0)
            {
                int currentWaste = 0;
                int currentGuest = guests.Peek();
                while (currentGuest > 0)
                {
                    int currentPlate = plates.Peek();
                    if (currentGuest - currentPlate <= 0)
                    {
                        currentWaste = Math.Abs(currentGuest - currentPlate);
                        guests.Dequeue();
                    }
                    plates.Pop();
                    currentGuest -= currentPlate;
                }
                waste += currentWaste;
            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            Console.WriteLine($"Wasted grams of food: {waste}");
        }
    }
}
