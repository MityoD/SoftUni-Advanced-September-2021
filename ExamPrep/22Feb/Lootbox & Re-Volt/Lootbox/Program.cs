using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //You need to start from the first item in the first box and sum it with the last item in the second box. If the sum of their values is an even number, add the summed item to your collection of claimed items and remove them both from the boxes. Otherwise, move the last item from the second box and add it at the last position in the first box. You need to stop summing items when one of the boxes becomes empty.

            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int collection = 0;
            while (firstBox.Count >0 && secondBox.Count > 0)
            {
                int currentCollection = firstBox.Peek() + secondBox.Peek();
                if (currentCollection % 2 == 0)
                {
                    collection += currentCollection;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int currentItem = secondBox.Pop();
                    firstBox.Enqueue(currentItem);
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (collection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collection}");
            }
        }
    }
}
