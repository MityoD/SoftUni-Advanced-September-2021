using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int gladiusValue = 70;
            int shamshirValue = 80;
            int katanaValue = 90;
            int sabreValue = 110;
            int broadswordValue = 150;

            int gladiusCount = 0;
            int shamshirCount = 0;
            int katanaCount = 0;
            int sabreCount = 0;
            int broadswordCount = 0;
            /*You should start from the first steel and try to mix it with the last carbon. If the sum of their values is equal to any of the swords in the table below you should forge the sword corresponding to the value and remove both the steel and the carbon. Otherwise, remove only the steel, increase the value of the carbon by 5 and insert it back into the collection. You need to stop forging when you have no more steel or carbon left.

*/

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int steelValue = steel.Dequeue();

                int carbonValue = carbon.Pop();


                int swordValue = steelValue + carbonValue;

                if (swordValue == gladiusValue)
                {
                    gladiusCount++;
                }
                else if (swordValue == shamshirValue)
                {
                    shamshirCount++;
                }
                else if (swordValue == katanaValue)
                {
                    katanaCount++;
                }
                else if (swordValue == sabreValue)
                {
                    sabreCount++;
                }
                else if (swordValue == broadswordValue)
                {
                    broadswordCount++;
                }
                else
                {
                    carbonValue += 5;
                    carbon.Push(carbonValue);
                }
            }

            int totalNumberOfSwords = gladiusCount + shamshirCount + katanaCount + sabreCount + broadswordCount;

            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (broadswordCount > 0)
            {
                Console.WriteLine($"Broadsword: {broadswordCount}");
            }
            if (gladiusCount > 0)
            {
                Console.WriteLine($"Gladius: {gladiusCount}");
            }
            if (katanaCount > 0)
            {
                Console.WriteLine($"Katana: {katanaCount}");
            }
            if (sabreCount > 0)
            {
                Console.WriteLine($"Sabre: {sabreCount}");
            }
            if (shamshirCount > 0)
            {
                Console.WriteLine($"Shamshir: {shamshirCount}");
            }
           
        }
    }
}
