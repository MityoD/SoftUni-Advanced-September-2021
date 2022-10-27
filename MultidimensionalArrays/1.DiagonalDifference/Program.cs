using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = input[j];
                }
            }
            int reverse = n;
            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < n; i++)
            {
                primarySum += array[i, i];
                secondarySum += array[i, reverse - 1];
                reverse--;
            }            
            int sum = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(sum);
        }
    }
}
