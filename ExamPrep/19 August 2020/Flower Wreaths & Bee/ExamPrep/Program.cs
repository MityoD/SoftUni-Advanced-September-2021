using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {


            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int flowersNeeded = 15;
            int flowersLeft = 0;
            int wreaths = 0;
            while (roses.Count > 0 && lilies.Count > 0/* && wreaths != 5*/)
            {
                int rose = roses.Peek();
                int lilie = lilies.Peek();

                int wreath = rose + lilie;

                if (wreath == flowersNeeded)
                {
                    wreaths += 1;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (wreath > flowersNeeded)
                {
                    lilie -= 2;
                    lilies.Pop();
                    lilies.Push(lilie);
                }
                else
                {
                    flowersLeft += roses.Dequeue() + lilies.Pop();
                  
                }
            }
            if (flowersLeft >= 15)
            {
                wreaths += flowersLeft / 15;
            }
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }            
        }
    }
}
