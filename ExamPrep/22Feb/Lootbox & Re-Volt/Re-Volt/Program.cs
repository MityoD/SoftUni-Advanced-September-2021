using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameWon = false;
            int rows = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] map = new char[rows, rows];
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < rows; j++)
                {
                    map[i, j] = input[j];
                    if (input[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }                
            }
            for (int i = 0; i < commands; i++)
            {
                int prevRow = playerRow;
                int prevCol = playerCol;
                map[playerRow, playerCol] = '-';
                string direction = Console.ReadLine();
                Movement(ref playerRow, ref playerCol, direction);
                IsOutside(rows, ref playerRow, ref playerCol);
                if (map[playerRow, playerCol] == 'T')
                {
                    playerRow = prevRow;
                    playerCol = prevCol;
                }
                else if (map[playerRow, playerCol] == 'B')
                {
                    Movement(ref playerRow, ref playerCol, direction);
                    IsOutside(rows, ref playerRow, ref playerCol);
                }
                if (map[playerRow, playerCol] == 'F')
                {
                    Console.WriteLine("Player won!");
                    map[playerRow, playerCol] = 'f';
                    gameWon = true;
                    break;
                }
                map[playerRow, playerCol] = 'f';
            }
            if (!gameWon)
            {
                Console.WriteLine("Player lost!");
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows ; j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void IsOutside(int rows, ref int playerRow, ref int playerCol)
        {
            if (playerRow < 0)
            {
                playerRow = rows - 1;
            }
            else if (playerRow > rows - 1)
            {
                playerRow = 0;
            }
            if (playerCol < 0)
            {
                playerCol = rows - 1;
            }
            else if (playerCol > rows - 1)
            {
                playerCol = 0;
            }
        }

        private static void Movement(ref int playerRow, ref int playerCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    playerRow -= 1;
                    break;
                case "down":
                    playerRow += 1;
                    break;
                case "left":
                    playerCol -= 1;
                    break;
                case "right":
                    playerCol += 1;
                    break;
            }
        }
    }
}
