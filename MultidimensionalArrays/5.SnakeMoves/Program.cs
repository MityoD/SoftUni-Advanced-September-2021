using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];
            char[,] matrix = new char[row, col];
            string snake = Console.ReadLine();
            Queue<char> snakeBody = new Queue<char>();
            for (int i = 0; i < snake.Length; i++)
            {
                snakeBody.Enqueue(snake[i]);                
            }
            for (int i = 0; i < row; i++)
            {   
                if (i % 2 == 0)
                {
                    for (int j = 0; j < col; j++)
                    {
                        char next = snakeBody.Dequeue();
                        matrix[i, j] = next;
                        snakeBody.Enqueue(next);
                    }
                }
                else
                {
                    for (int j = col - 1; j >= 0; j--)
                    {
                        char next = snakeBody.Dequeue();
                        matrix[i, j] = next;
                        snakeBody.Enqueue(next);                        
                    }
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
