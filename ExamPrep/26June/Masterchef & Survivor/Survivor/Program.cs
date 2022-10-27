using System;
using System.Linq;

namespace Survivor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] map = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                map[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }
            string command = "";
            int personTokens = 0;
            int oponentTokens = 0;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "Find")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    if (IsInside(row, col) && map[row][col] == 'T')
                    {
                        personTokens++;
                        map[row][col] = '-';
                    }
                }
                else if (commandArgs[0] == "Opponent")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    string direction = commandArgs[3];
                    if (IsInside(row, col) && map[row][col] == 'T')
                    {
                        oponentTokens++;
                        map[row][col] = '-';
                    }
                    if (IsInside(row, col))
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            switch (direction)
                            {
                                case "up":
                                    row--;
                                    break;
                                case "down":
                                    row++;
                                    break;
                                case "left":
                                    col--;
                                    break;
                                case "right":
                                    col++;
                                    break;
                            }
                            if (IsInside(row, col) && map[row][col] == 'T')
                            {
                                oponentTokens++;
                                map[row][col] = '-';
                            }
                        }
                    }
                }
                //foreach (var item in map)
                //{
                //    Console.WriteLine(string.Join(" ", item));
                //}
            }
            foreach (var item in map)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            Console.WriteLine($"Collected tokens: {personTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");

            bool IsInside(int row, int col)
            {
                if (row >= 0 && row < rows && col >= 0 && col < map[row].Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
