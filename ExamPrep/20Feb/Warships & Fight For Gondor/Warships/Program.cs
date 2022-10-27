using System;
using System.Collections.Generic;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            bool IsInside(int row, int col) => row >= 0 && row < rows && col >= 0 && col < rows;
            char[,] map = new char[rows, rows];
            string[] input = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            Queue<int[]> atackCoordinates = new Queue<int[]>();
            for (int i = 0; i < input.Length; i++)
            {
                atackCoordinates.Enqueue(input[i].Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }
            int playerOne = 0;
            int playerTwo = 0;
            for (int i = 0; i < rows; i++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int j = 0; j < rows; j++)
                {
                    map[i, j] = char.Parse(elements[j]);
                    if (elements[j] == "<")
                    {
                        playerOne++;
                    }
                    else if (elements[j] == ">")
                    {
                        playerTwo++;
                    }
                }
            }
            int totalShips = playerOne + playerTwo;
            while (atackCoordinates.Count > 0 && playerOne > 0 && playerTwo > 0)
            {
                int[] currentIndexes = atackCoordinates.Dequeue();
                int row = currentIndexes[0];
                int col = currentIndexes[1];

                if (IsInside(row, col))
                {
                    if (map[row, col] == '#')
                    {
                        if (IsInside(row - 1, col - 1))
                        {
                            if (map[row - 1, col - 1] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row - 1, col - 1] == '>')
                            {
                                playerTwo--;
                            }
                            map[row - 1, col - 1] = 'X';
                        }
                        if (IsInside(row - 1, col))
                        {
                            if (map[row - 1, col] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row - 1, col] == '>')
                            {
                                playerTwo--;
                            }
                            map[row - 1, col] = 'X';
                        }
                        if (IsInside(row - 1, col + 1))
                        {
                            if (map[row - 1, col + 1] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row - 1, col + 1] == '>')
                            {
                                playerTwo--;
                            }
                            map[row - 1, col + 1] = 'X';
                        }
                        if (IsInside(row, col - 1))
                        {
                            if (map[row, col - 1] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row, col - 1] == '>')
                            {
                                playerTwo--;
                            }
                            map[row, col - 1] = 'X';
                        }
                        if (IsInside(row, col + 1))
                        {
                            if (map[row, col + 1] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row, col + 1] == '>')
                            {
                                playerTwo--;
                            }
                            map[row, col + 1] = 'X';
                        }
                        if (IsInside(row + 1, col - 1))
                        {
                            if (map[row + 1, col - 1] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row + 1, col - 1] == '>')
                            {
                                playerTwo--;
                            }
                            map[row + 1, col - 1] = 'X';
                        }
                        if (IsInside(row + 1, col))
                        {
                            if (map[row + 1, col] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row + 1, col] == '>')
                            {
                                playerTwo--;
                            }
                            map[row + 1, col] = 'X';
                        }
                        if (IsInside(row + 1, col + 1))
                        {
                            if (map[row + 1, col + 1] == '<')
                            {
                                playerOne--;
                            }
                            else if (map[row + 1, col + 1] == '>')
                            {
                                playerTwo--;
                            }
                            map[row + 1, col + 1] = 'X';
                        }
                        map[row, col] = 'X';
                    }
                    else if (map[row, col] == '<')
                    {
                        map[row, col] = 'X';
                        playerOne--;
                    }
                    else if (map[row, col] == '>')
                    {
                        map[row, col] = 'X';
                        playerTwo--;
                    }
                }
            }
            if (playerTwo <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - playerOne} ships have been sunk in the battle.");
            }
            else if (playerOne <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - playerTwo} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOne} ships left. Player Two has {playerTwo} ships left.");
            }

        }

    }
}
