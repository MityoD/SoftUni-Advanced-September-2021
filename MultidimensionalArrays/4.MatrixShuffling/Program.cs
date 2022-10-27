using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];
            string[,] matrix = new string[row, col];
            for (int i = 0; i < row; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split();
                string action = commandArgs[0];
                if (!command.Contains("swap") || commandArgs.Length != 5 || int.Parse(commandArgs[1]) < 0 || int.Parse(commandArgs[1]) > row - 1 || int.Parse(commandArgs[2]) < 0 || int.Parse(commandArgs[2]) > col - 1 || int.Parse(commandArgs[3]) < 0 || int.Parse(commandArgs[3]) > row - 1 || int.Parse(commandArgs[4]) < 0 || int.Parse(commandArgs[4]) > col - 1)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int indexRow1 = int.Parse(commandArgs[1]);
                int indexCol1 = int.Parse(commandArgs[2]);
                int indexRow2 = int.Parse(commandArgs[3]);
                int indexCol2 = int.Parse(commandArgs[4]);
                string firstToSwap = matrix[indexRow1, indexCol1];
                matrix[indexRow1, indexCol1] = matrix[indexRow2, indexCol2];
                matrix[indexRow2, indexCol2] = firstToSwap;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write(matrix[i,j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
