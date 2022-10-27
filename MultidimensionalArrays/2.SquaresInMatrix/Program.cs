using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];
            char [,] matrix = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = char.Parse(input[j]);
                }
            }
            int counter = 0;
            for (int i = 0; i < row -1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    if (matrix[i,j] == matrix[i, j+1] && matrix[i, j] == matrix[i + 1, j] && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        counter++; 
                    }
                }
            }
            Console.WriteLine(counter);

        }
    }
}
