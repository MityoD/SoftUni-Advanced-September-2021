using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            /*You will be given N and M – integers, indicating the dimensions of the square garden. The garden is empty at the beginning – it has no flowers. Furion wants every place for a flower to be presented with a zero (0) when it is empty. After you finish creating the garden, you will start receiving two integers – Row and Column, separated by a single space – which represent the position at which Furion currently plants a flower. If you receive a position, which is outside of the garden, you should print "Invalid coordinates." and move on with the next position. This happens until you receive the command "Bloom Bloom Plow”. When you receive that input, all planted flowers should bloom.
The flowers are magical. When a flower blooms it instantly blooms flowers to all places to its left, right, up, and down, increasing their value with 1. Flowers can bloom multiple times, and each time the flower blooms – it becomes more and more beautiful, which means its value increases by 1. */



            int[] gardenSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int gardenRow = gardenSize[0];
            int gardenCol = gardenSize[1];
            int[,] garden = new int[gardenRow, gardenCol];

            for (int i = 0; i < gardenRow; i++)
            {
                for (int j = 0; j < gardenCol; j++)
                {
                    garden[i, j] = 0;
                }
            }

            //for (int i = 0; i < garden.GetLength(0); i++)
            //{
            //    for (int j = 0; j < garden.GetLength(1); j++)
            //    {
            //        Console.Write($"{garden[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int flowerRow = coordinates[0];
                int flowerCol = coordinates[1];
                if (!IsInside(flowerRow, flowerCol, gardenRow, gardenCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[flowerRow, i] += 1;
                }

                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[j, flowerCol] += 1;
                }

                garden[flowerRow, flowerCol] = 1;
                             
            }
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }


        }

        private static bool IsInside(int row, int col, int gardenRow, int gardenCol) => row >= 0 && row < gardenRow && col >= 0 && col < gardenCol;
    }
}
