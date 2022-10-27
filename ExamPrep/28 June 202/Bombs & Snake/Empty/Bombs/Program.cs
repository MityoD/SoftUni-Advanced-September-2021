using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int daturaBombs = 40;
            int cherryBomb = 60;
            int smokeDecoyBombs = 120;

            int darutaCount = 0;
            int cherryCount = 0;
            int smokeCount = 0;

            while (bombEffects.Count > 0 && bombCasing.Count > 0/* && darutaCount != 3 && cherryCount != 3 && smokeCount != 3*/)
            {
                int currentValue = bombCasing.Peek() + bombEffects.Peek();

                if (currentValue == daturaBombs)
                {
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                    darutaCount++;
                }
                else if (currentValue == cherryBomb)
                {
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                    cherryCount++;
                }
                else if (currentValue == smokeDecoyBombs)
                {
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                    smokeCount++;
                }
                else
                {
                    int newValue = bombCasing.Pop() - 5;
                    bombCasing.Push(newValue);
                }
                if (darutaCount >= 3 && cherryCount >= 3 && smokeCount >=3)
                {
                    break;
                }
            }
            if (darutaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count != 0)
            {
                Console.WriteLine($"Bomb Effects: { string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }


            if (bombCasing.Count != 0)
            {
                Console.WriteLine($"Bomb Casings: { string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {darutaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");

            /*	•	Datura Bombs: 40
	•	Cherry Bombs: 60
	•	Smoke Decoy Bombs: 120
*/


        }
    }
}
